using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Hotel.DataAccess.BDModels
{
    public partial class TiposCliente
    {
        public TiposCliente()
        {
            Clientes = new HashSet<Clientes>();
        }

        [Display(Name = "Id")]
        [Key]
        public int TipoClienteId { get; set; }
        [Display(Name = "Tipo Cliente")]
        public string TipoCliente { get; set; }
        [Display(Name = "% Descuento")]
        public byte PorcentajeDescuento { get; set; }

        public virtual ICollection<Clientes> Clientes { get; set; }
    }
}
