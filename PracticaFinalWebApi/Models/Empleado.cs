using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PracticaFinalWebApi.Models
{
    [Table("Empleado")]
    public class Empleado
    {
        private int codEmpleado;
        [Key]
        public int CodEmpleado
        {
            get { return codEmpleado; }
            set { codEmpleado = value; }
        }

        private string nombre;
        [Required]
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        private string apellido;
        [Required]
        public string Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }

        private double salario;
        [Column(TypeName = "money")]
        public double Salario
        {
            get { return salario; }
            set { salario = value; }
        }

        private Oficina codOficina;
        [Required]
        [ForeignKey("Oficina")]
        public Oficina CodOficina
        {
            get { return codOficina; }
            set { codOficina = value; }
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
