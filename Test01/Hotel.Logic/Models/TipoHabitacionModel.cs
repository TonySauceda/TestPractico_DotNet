using System.ComponentModel.DataAnnotations;

namespace Hotel.Logic.Models
{
    public class TipoHabitacionModel
    {
        [Display(Name = "Id")]
        public int TipoHabitacionId { get; set; }
        [Display(Name = "Tipo Habitacion")]
        public string TipoHabitacion { get; set; }
        public decimal Precio { get; set; }
        public string Foto { get; set; }
    }
}
