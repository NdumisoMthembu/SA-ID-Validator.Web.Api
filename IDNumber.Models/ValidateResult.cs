using System;
using System.Collections.Generic;

namespace IDNumber.Models
{
    public class ValidateResult
    {
        public string IdentityNumber { get; set; }
        public bool IsValid { get; set; }
        public List<string> Reasons { get; set; }
        public ValidateResult(string IdentityNumber, bool IsValid, List<string> Reasons)
        {
            this.IdentityNumber = IdentityNumber;
            this.IsValid = IsValid;
            this.Reasons = Reasons;
        }

    }

}
   
