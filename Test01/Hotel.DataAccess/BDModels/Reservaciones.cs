using System;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Hotel.DataAccess.BDModels
{
    public partial class Reservaciones
    {
        [Display(Name = "Id")]
        [Key]
        public int ReservacionId { get; set; }
        public int ClienteId { get; set; }
        public int HabitacionId { get; set; }
        [Display(Name = "Fecha Inicial")]
        public DateTime FechaInicial { get; set; }
        [Display(Name = "Fecha Final")]
        public DateTime FechaFinal { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int UsuarioId { get; set; }

        public virtual Clientes Cliente { get; set; }
        public virtual Habitaciones Habitacion { get; set; }
        public virtual Usuarios Usuario { get; set; }
    }
}
