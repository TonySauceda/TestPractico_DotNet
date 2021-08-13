using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Logic.Models
{
    public class HabitacionModel
    {
        [Display(Name = "Id")]
        public int HabitacionId { get; set; }
        [Display(Name = "Habitación")]
        public string Habitacion { get; set; }
        [Display(Name = "Tipo Habitación")]
        public string TipoHabitacion { get; set; }
        public decimal Precio { get; set; }
        public string Foto { get; set; }
    }
}
