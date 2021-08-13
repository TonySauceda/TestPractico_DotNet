using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.WebApp.Utils
{
    public class Constantes
    {
        public class VistaParcial
        {
            public const string TablaHabitacion = "~/Views/Shared/_TablaHabitacionPartial.cshtml";
            public const string TablaTipoCliente = "~/Views/Shared/_TablaTipoClientePartial.cshtml";
            public const string TablaReservaciones = "~/Views/Shared/_TablaReservacionesPartial.cshtml";
            public const string TablaTipoHabitacion = "~/Views/Shared/_TablaTipoHabitacionPartial.cshtml";
            public const string Reporte = "~/Views/Shared/_ReportePartial.cshtml";
            public const string LoginStatus = "~/Views/Shared/_LoginStatusPartial.cshtml";
        }

        public class Identity
        {
            public const string Auth = "_Auth_";
            public class Rol
            {
                public const string Administrador = "Administrador";
                public const string Recepcionista = "Recepcionista";
            }
        }
    }
}
