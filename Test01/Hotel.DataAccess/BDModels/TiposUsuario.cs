using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Hotel.DataAccess.BDModels
{
    public partial class TiposUsuario
    {
        public TiposUsuario()
        {
            Usuarios = new HashSet<Usuarios>();
        }

        [Display(Name = "Id")]
        [Key]
        public int TipoUsuarioId { get; set; }
        [Display(Name = "Tipo Usuario")]
        public string TipoUsuario { get; set; }

        public virtual ICollection<Usuarios> Usuarios { get; set; }
    }
}
