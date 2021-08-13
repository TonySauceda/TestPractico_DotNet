using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Logic.Models
{
    public class ReservacionModel
    {
        public int ReservacionId { get; set; }
        public int ClienteId { get; set; }
        public int HabitacionId{ get; set; }
        public DateTime FechaInicial { get; set; }
        public DateTime FechaFinal { get; set; }
    }
}
