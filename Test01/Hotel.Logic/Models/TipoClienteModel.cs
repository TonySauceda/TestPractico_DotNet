using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Logic.Models
{
    public class TipoClienteModel
    {
        [Display(Name = "Id")]
        public int TipoClienteId { get; set; }
        [Display(Name = "Tipo Cliente")]
        public string TipoCliente { get; set; }
        [Display(Name = "% Descuento")]
        public byte PorcentajeDescuento { get; set; }
    }
}
