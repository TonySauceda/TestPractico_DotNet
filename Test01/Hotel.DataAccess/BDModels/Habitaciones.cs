using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Hotel.DataAccess.BDModels
{
    public partial class Habitaciones
    {
        public Habitaciones()
        {
            Reservaciones = new HashSet<Reservaciones>();
        }

        [Display(Name = "Id")]
        [Key]
        public int HabitacionId { get; set; }
        [Display(Name = "Habitación")]
        public string Habitacion { get; set; }
        public int TipoHabitacionId { get; set; }

        public virtual TiposHabitacion TipoHabitacion { get; set; }
        public virtual ICollection<Reservaciones> Reservaciones { get; set; }
    }
}
