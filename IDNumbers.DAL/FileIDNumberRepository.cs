using System;
using System.Collections.Generic;
using System.Text;
using IDNumber.Models;
using System.IO;

namespace IDNumbers.DAL
{
   public class FileIDNumberRepository : IIDNumberRepository
    {
        public void AddRange(List<IDNumberDetails> numbers)
        {
            StringBuilder fileData = new StringBuilder();
            foreach ( IDNumberDetails idnumber in numbers)
            {
                fileData.Append(String.Format("{0}, {1} \n", idnumber.BirthDate , idnumber.Citizenship));
            }
            string data = fileData.ToString();
            string filename = MakeDir("valid.txt");
            StreamWriter File = new StreamWriter(filename);
            File.Write(data);
            File.Close();

        }
        public List<IDNumberDetails> GetAll()
        {
            return null ;
        }
        private string MakeDir(string filename)
        {
            System.IO.Directory.CreateDirectory(@"C:\demodb");
            string path = @"C:\demodb\" + filename;
            return path;
        }
    }
}
