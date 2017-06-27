using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Estadias.Models
{
    public class Empresa
    {
        [Key]
        [Required]
        public int empresaID { get; set; }

        [Required]
        [Display(Name = "Nombre Empresa")]
        public string nombreEmpresa { get; set; }

        [Required]
        [Display(Name = "Espacios Disponibles")]
        public int espacios { get; set; }

        [Required]
        [Display(Name = "Representante")]
        public string representanteEmpresa { get; set; }

        [Display(Name = "Teléfono")]
        [DataType(DataType.PhoneNumber)]
        public string telefono { get; set; }

        [Display(Name = "Dirección")]
        public string direccion { get; set; }
    }
}