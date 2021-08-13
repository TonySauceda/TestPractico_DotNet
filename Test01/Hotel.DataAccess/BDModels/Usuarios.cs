using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Hotel.DataAccess.BDModels
{
    public partial class Usuarios
    {
        public Usuarios()
        {
            Reservaciones = new HashSet<Reservaciones>();
        }

        [Display(Name = "Id")]
        [Key]
        public int UsuarioId { get; set; }
        public string Nombre { get; set; }
        [Display(Name = "Apellido Paterno")]
        public string ApellidoPaterno { get; set; }
        [Display(Name = "Apellido Materno")]
        public string ApellidoMaterno { get; set; }
        public string Usuario { get; set; }
        public string Contrasena { get; set; }
        public int TipoUsuarioId { get; set; }
        public bool Activo { get; set; }

        public virtual TiposUsuario TipoUsuario { get; set; }
        public virtual ICollection<Reservaciones> Reservaciones { get; set; }
    }
}
