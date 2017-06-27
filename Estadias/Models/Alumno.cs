using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Estadias.Models
{
    public class Alumno
    {
        [Key]
        [Required]
        [Display(Name = "Expediente")]
        public string alumnoID { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        public string nombreAlumno { get; set; }

        [Required]
        [Display(Name = "Apellido Paterno")]
        public string apellidoPaterno { get; set; }

        [Required]
        [Display(Name = "Apellido Materno")]
        public string apellidoMaterno { get; set; }

        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }

        [Display(Name = "Seguro Social")]
        [Required]
        public string seguroSocial { get; set; }

        [Display(Name ="Nombre")]
        public string nombreCompleto
        {
            get
            {
                return string.Format($"({this.nombreAlumno.ToUpper()} { this.apellidoPaterno.ToUpper()} { this.apellidoMaterno.ToUpper()}");
            }
        }

        [Required]
        [Display(Name = "Carrera")]
        public string carreraID { get; set; }
        virtual public Carrera carrera { get; set; }

        virtual public ICollection<Carrera> carreras { get; set; }
    }
}