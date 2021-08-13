using Hotel.DataAccess.BDModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.WebApp.Models
{
    public class ReporteViewModel
    {
        public ReporteViewModel(List<Reservaciones> reservaciones)
        {
            Reservaciones = reservaciones;
        }
        private List<Reservaciones> Reservaciones { get; set; }

        public int TotalReservaciones
        {
            get
            {
                return Reservaciones.Count;
            }
        }
        public decimal Total
        {
            get
            {
                decimal resultado = 0;

                foreach (var reservacion in Reservaciones)
                {
                    decimal precio = reservacion.Habitacion?.TipoHabitacion?.Precio ?? 0;
                    int dias = (int)(reservacion.FechaFinal - reservacion.FechaInicial).TotalDays + 1;
                    decimal porcentajeDescuento = ((decimal)reservacion.Cliente.TipoCliente.PorcentajeDescuento / 100);
                    decimal total = precio * dias;
                    decimal descuento = total * porcentajeDescuento;
                    resultado += total - descuento;
                }

                return resultado;
            }
        }

        public decimal Descuento
        {
            get
            {
                decimal resultado = 0;

                foreach (var reservacion in Reservaciones)
                {
                    decimal precio = reservacion.Habitacion?.TipoHabitacion?.Precio ?? 0;
                    int dias = (int)(reservacion.FechaFinal - reservacion.FechaInicial).TotalDays + 1;
                    decimal porcentajeDescuento = ((decimal)reservacion.Cliente.TipoCliente.PorcentajeDescuento / 100);
                    decimal total = precio * dias;
                    decimal descuento = total * porcentajeDescuento;
                    resultado += descuento;
                }

                return resultado;
            }
        }
    }
}
