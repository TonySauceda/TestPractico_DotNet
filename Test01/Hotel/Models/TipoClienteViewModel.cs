using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.WebApp.Models
{
    public class TipoClienteViewModel
    {
        public int TipoClienteId { get; set; }
        [Required(ErrorMessage = "El tipo de cliente es obligatorio.")]
        [StringLength(50, ErrorMessage = "El tipo de cliente no puede ser mayor a 50 caracteres.")]
        [Display(Name = "Tipo Cliente")]
        public string TipoCliente { get; set; }
        public byte PorcentajeDescuento { get; set; }
    }
}
