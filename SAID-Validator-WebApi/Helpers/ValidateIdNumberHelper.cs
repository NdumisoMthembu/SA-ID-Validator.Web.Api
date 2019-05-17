using IDNumber.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAIDValidator.Web.Api.Helpers
{
    public class ValidateIdNumberHelper
    {
        /// <summary>
        /// This Funtions validates the Id number using  the Luhn algorithm
        /// </summary>
        /// <param name="IdNumber"></param>
        /// <returns></returns>
        public static ValidateResult Validate(string IdNumber)
        {
            List<string> reasons = new List<string>();
            if (IdNumber.Length != 13) {
                reasons.Add("Id Number is not 13 digits");
                return new ValidateResult(IdNumber, false, reasons);
            }

            var isNumeric = long.TryParse(IdNumber, out long n);
            if (!isNumeric)
            {
                reasons.Add("Id Number contains invalid charecters");
                return new ValidateResult(IdNumber, false, reasons);
            }

            int oddSums = 0;
            int checkDigit = int.Parse(IdNumber[IdNumber.Length - 1].ToString()); // Last Digit ot the ID number
            StringBuilder evenPositionStr = new StringBuilder();
                
            for(int i=0; i< IdNumber.Length; i++)
            {
                if((i+1) % 2 == 0)
                {
                    // Append odd possions to a string 
                    evenPositionStr.Append((IdNumber[i]));
                }
                else if((i + 1) % 2 >0 && i<IdNumber.Length-2)
                {
                    // Add all numbers on odd possions, but not the last digit
                    oddSums += int.Parse(IdNumber[i].ToString());
                }
            }

            int evenPositionDoubled = int.Parse(evenPositionStr.ToString())*2;
            int evenPositionDoubledSum = 0;
            foreach (char item in evenPositionDoubled.ToString().ToArray())
            {
                evenPositionDoubledSum += int.Parse(item.ToString());
            }

            int combineSums = evenPositionDoubledSum + oddSums;
            if(Math.Abs(int.Parse(combineSums.ToString()[1].ToString()) - 10) != checkDigit)
            {
                reasons.Add("ID number vaildation did not meet requiremrnts");
                return new ValidateResult(IdNumber,false, reasons);
            }
            return new ValidateResult(IdNumber, true, reasons);
        }
    }
}
