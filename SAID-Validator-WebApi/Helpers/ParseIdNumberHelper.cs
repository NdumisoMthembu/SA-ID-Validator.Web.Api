using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDNumber.Models;

namespace SAIDValidator.Web.Api.Helpers
{
    public class ParseIdNumberHelper
    {
        /// <summary>
        /// This Funtions parse the Id number to an Object 
        /// </summary>
        /// <param name="IdNumber"></param>
        /// <returns></returns>
         public static IDNumberDetails Parse(string IdNumber)
        {
            DateTime dob = ParseDate(IdNumber.Substring(0, 6));
            string gender = int.Parse(IdNumber.Substring(6, 4)) <= 4999? "Female" : "Male";
            string citzen = int.Parse(IdNumber[10].ToString()) == 0 ? "SA Citizen" : "Permanent Resident";
            return new IDNumberDetails(IdNumber, dob.ToLongDateString(), gender, citzen,"valid");
        }
      

        private static DateTime ParseDate(string date)
        {
            string DOB = String.Format("{0}-{1}-19{2}", date.Substring(4, 2), date.Substring(2,2), date.Substring(0,2)); // to fix the year
            var iDate = DateTime.ParseExact(DOB, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            return iDate;
        }
    }
}
