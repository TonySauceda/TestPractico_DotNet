using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Hotel.DataAccess.BDModels
{
    public partial class Clientes
    {
        public Clientes()
        {
            Reservaciones = new HashSet<Reservaciones>();
        }

        [Display(Name = "Id")]
        [Key]
        public int ClienteId { get; set; }
        public string Nombre { get; set; }
        [Display(Name = "Apellido Paterno")]
        public string ApellidoPaterno { get; set; }
        [Display(Name = "Apellido Materno")]
        public string ApellidoMaterno { get; set; }
        public int TipoClienteId { get; set; }

        public virtual TiposCliente TipoCliente { get; set; }
        public virtual ICollection<Reservaciones> Reservaciones { get; set; }
    }
}
