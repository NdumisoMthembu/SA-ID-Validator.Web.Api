using IDNumber.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IDNumbers.DAL
{
   public interface IIDNumberRepository
    {
        void AddRange(List<IDNumberDetails> numbers);
        List<IDNumberDetails> GetAll();
    }
}
