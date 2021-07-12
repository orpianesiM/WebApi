using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PracticaFinalWebApi.Models
{
    [Table("Vehiculo")]
    public class Auto
    {
        private int id;
        [Key]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string marca;
        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public string Marca
        {
            get { return marca; }
            set { marca = value; }
        }

        private string modelo;
        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public string Modelo
        {
            get { return modelo; }
            set { modelo = value; }
        }

        private string color;
        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public string Color
        {
            get { return color; }
            set { color = value; }
        }
        private double precio;
        [Column(TypeName = "money")]
        public double Precio
        {
            get { return precio; }
            set { precio = value; }
        }

        private List<Reserva> reservas;
        [Required]
        [ForeignKey("Reservas")]
        public List<Reserva> Reservas
        {
            get { return reservas; }
            set { reservas = value; }
        }

    }
}
