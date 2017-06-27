using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Estadias.Models
{
    public class Carrera
    {
        [Key]
        [Required]
        [Display(Name = "Clave Carrera")]
        public string carreraID { get; set; }

        [Required]
        [Display(Name = "Nombre Carrera")]
        public string nombreCarrera { get; set; }
    }
}