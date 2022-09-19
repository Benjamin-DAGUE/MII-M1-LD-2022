using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursLinq
{
    public static class DateTimeExtension
    {
        public static int CalculateAge(this DateTime birthDate)
        {
            int age = DateTime.Now.Year - birthDate.Year;

            if (DateTime.Now.DayOfYear < birthDate.DayOfYear)
            {
                age--;
            }

            return age;
        }
    }
}
