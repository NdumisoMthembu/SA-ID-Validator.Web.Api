using System;
using System.Collections.Generic;

namespace IDNumber.Models
{
    public class IDNumberDetails
    {
        public string IdentityNumber { get; set; }
        public string BirthDate { get; set; }
        public string Gender { get; set; }
        public string Citizenship { get; set; }
        public List<string> Reasons { get; set; }
        public string Status { get; set; }


        public IDNumberDetails(string IdentityNumber,string Status, List<string> Reasons) {
            this.IdentityNumber = IdentityNumber;
            this.Status = Status;
            this.Reasons = Reasons;
        }

        public IDNumberDetails(string IdentityNumber, string BirthDate, string Gender, string Citizenship, string Status)
        {
            this.IdentityNumber = IdentityNumber;
            this.BirthDate = BirthDate;
            this.Gender = Gender;
            this.Citizenship = Citizenship;
            this.Status = Status;
        }


    }

}
   
