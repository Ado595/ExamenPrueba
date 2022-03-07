using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenPrueba.Helpers
{
    public static class HelperDateTime
    {
        public static DateTime GetAge(DateTime? dateBirthD)
        {
            try
            {
                DateTime thisDay = DateTime.Today;
                TimeSpan age = (TimeSpan)(thisDay - dateBirthD);
                return new DateTime(age.Ticks);
            }
            catch
            {
                return DateTime.Today;
            }
        }
    }
}
