using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PracticaFinalWebApi.Models
{
    [Table("Oficina")]
    public class Oficina
    {
        private int codOficina;
        [Key]
        public int CodOficina
        {
            get { return codOficina; }
            set { codOficina = value; }
        }

        private string direccion;
        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }

        private string localidad;
        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public string Localidad
        {
            get { return localidad; }
            set { localidad = value; }
        }

        private string provincia;
        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public string Provincia
        {
            get { return provincia; }
            set { provincia = value; }
        }

        private List<Empleado> empleados;
        [Required]
        [ForeignKey("Empleados")]
        public List<Empleado> Empleados
        {
            get { return empleados; }
            set { empleados = value; }
        }

    }
}
