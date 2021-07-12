using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticaFinalWebApi.Data;
using PracticaFinalWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticaFinalWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoController : ControllerBase
    {
       private readonly ApplicationDbContext _context;
        public AutoController(ApplicationDbContext context)
        {
            _context = context;
        }

       //GET ALL
        [HttpGet]
        public IEnumerable<Auto> Get()
        {
            return _context.Autos.ToList();
        }

        //GET BY ID
        [HttpGet("getid/{id}")]
        public ActionResult<Auto> GetById(int id)
        {
            return _context.Autos.Find(id);
        }

        //INSERT
        [HttpPost]
        public ActionResult Post(Auto auto)
        {
            _context.Autos.Add(auto);
            _context.SaveChanges();

            return Ok();
        }

        //UPDATE
        [HttpPut("{id}")]
        public ActionResult<Auto> Put(int id, [FromBody] Auto auto)
        {
            if (id != auto.Id)
            {
                return BadRequest();
            }

            _context.Entry(auto).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok();
        }

        //DELETE
        [HttpDelete("{id}")]
        public ActionResult<Auto> Delete(int id)
        {
            var auto = _context.Autos.Find(id);
            if (auto == null)
            {
                return NotFound();
            }
            _context.Autos.Remove(auto);
            _context.SaveChanges();

            return auto;
        }

        //GET BY MARCA
        [HttpGet("getmarca/{marca}")]
        public IEnumerable<Auto> GetByMarca(string marca)
        {
            var autos = (from a in _context.Autos
                            where a.Marca.Contains(marca)
                            select a).ToList();

            return autos;
        }

        //GET BY MODELO
        [HttpGet("getmodelo/{modelo}")]
        public IEnumerable<Auto> GetByModelo(string modelo)
        {
            var autos = (from a in _context.Autos
                         where a.Marca.Contains(modelo)
                         select a).ToList();

            return autos;
        }

        //GET BY MARCA&MODELO
        [HttpGet("getmarcaymodelo/{marca}/{modelo}")]
        public IEnumerable<Auto> GetByMM(string marca, string modelo)
        {
            var autos = (from a in _context.Autos
                         where a.Marca.Contains(marca) && a.Modelo == modelo
                         select a).ToList();

            return autos;
        }

    }
}
