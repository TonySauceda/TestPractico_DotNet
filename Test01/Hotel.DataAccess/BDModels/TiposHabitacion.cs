using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Hotel.DataAccess.BDModels
{
    public partial class TiposHabitacion
    {
        public TiposHabitacion()
        {
            Habitaciones = new HashSet<Habitaciones>();
        }

        [Display(Name = "Id")]
        [Key]
        public int TipoHabitacionId { get; set; }
        [Display(Name = "Tipo Habitación")]
        public string TipoHabitacion { get; set; }
        public decimal Precio { get; set; }
        public string Foto { get; set; }

        public virtual ICollection<Habitaciones> Habitaciones { get; set; }
    }
}
