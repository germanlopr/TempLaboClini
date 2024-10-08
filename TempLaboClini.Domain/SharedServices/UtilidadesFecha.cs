using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TempLaboClini.Domain.SharedServices
{
    public static class UtilidadesFecha
    {
        public static int CalcularEdad(DateTime fechaNacimiento)
        {
            var hoy = DateTime.Today;
            var edad = hoy.Year - fechaNacimiento.Year;
            if (fechaNacimiento.Date > hoy.AddYears(-edad)) edad--;
            return edad;
        }

        public static int? CalcularEdadAnios(DateTime? fechaNacimiento)
        {
            if (fechaNacimiento == null)
                return null;
            return DateTime.Today.Year - fechaNacimiento.Value.Year;
        }

        public static int? CalcularEdadMeses(DateTime? fechaNacimiento)
        {
            if (fechaNacimiento == null)
                return null;
            var edad = DateTime.Today - fechaNacimiento.Value;
            return edad.Days / 30;
        }
    }

}
