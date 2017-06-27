using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Estadias.Models
{
    public class Registro
    {
        [Key]
        [Display(Name = "Folio")]
        public int registroID { get; set; }

        [Required]
        [Display(Name = "Expediente")]
        public string alumnoID { get; set; }
        [Display(Name ="Expediente")]
        virtual public Alumno alumno { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime fecha { get; set; }

        [Required]
        [Display(Name = "Empresa")]
        public int empresaID { get; set; }
        [Required]
        [Display(Name ="Empresa")]
        virtual public Empresa empresa { get; set; }
    }
}