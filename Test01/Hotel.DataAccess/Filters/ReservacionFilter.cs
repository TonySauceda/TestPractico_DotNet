using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.DataAccess.Filters
{
    public class ReservacionFilter
    {
        public DateTime? FechaIngresoInicial { get; set; }
        public DateTime? FechaIngresoFinal { get; set; }

        public DateTime? FechaSalidaInicial { get; set; }
        public DateTime? FechaSalidaFinal { get; set; }
        public int ClienteId { get; set; }
        public string Habitacion { get; set; }
    }
}
