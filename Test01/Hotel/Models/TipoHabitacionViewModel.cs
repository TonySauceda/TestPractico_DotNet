using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.WebApp.Models
{
    public class TipoHabitacionViewModel
    {
        public int TipoHabitacionId { get; set; }
        [Required(ErrorMessage = "El tipo de habitación es obligatorio.")]
        [StringLength(50, ErrorMessage = "El tipo de habitación no puede ser mayor a 50 caracteres.")]
        [Display(Name = "Tipo Habitación")]
        public string TipoHabitacion { get; set; }
        [Required(ErrorMessage = "El precio es obligatorio.")]
        public decimal Precio { get; set; }
    }
}
