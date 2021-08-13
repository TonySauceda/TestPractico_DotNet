using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.WebApp.Models
{
    public class NuevaReservacionViewModel
    {
        [Display(Name = "Cliente")]
        public int ClienteId { get; set; }
        [Display(Name = "Habitacion")]
        public int TipoHabitacionId { get; set; }
        [Required(ErrorMessage = "La fecha es obligatoria.")]
        public DateTime Fecha { get; set; }
        [Required(ErrorMessage = "Los días son obligatorios.")]
        [Range(1, int.MaxValue)]
        [Display(Name = "Días")]
        public int Dias { get; set; }
    }
}
