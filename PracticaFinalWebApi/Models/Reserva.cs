using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PracticaFinalWebApi.Models
{
    [Table("Reserva")]
    public class Reserva
    {
        private int codReserva;
        [Key]
        public int CodReserva
        {
            get { return codReserva; }
            set { codReserva = value; }
        }

        private Auto codVehiculo;
        [Required]
        [ForeignKey("Vehiculo")]
        public Auto CodVehiculo
        {
            get { return codVehiculo; }
            set { codVehiculo = value; }
        }

        private DateTime? fecha;

        public DateTime? Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        private string destino;
        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public string Destino
        {
            get { return destino; }
            set { destino = value; }
        }

        private double kilometros;

        public double Kilometros
        {
            get { return kilometros; }
            set { kilometros = value; }
        }

        private Empleado codEmpleado;
        [Required]
        [ForeignKey("Empleado")]
        public Empleado CodEmpleado
        {
            get { return codEmpleado; }
            set { codEmpleado = value; }
        }

        

    }
}
