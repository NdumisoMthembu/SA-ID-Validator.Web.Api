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
            StringBuilder fileData2 = new StringBuilder();
            string filename = MakeDir("valid.txt");
            string filename2 = MakeDir("invalid.txt");
            StreamWriter File = new StreamWriter(filename);
            StreamWriter File2 = new StreamWriter(filename2);
            foreach (IDNumberDetails idnumber in numbers)
            {
                if (idnumber.Status == "valid")
                {
                    File.Write($"{idnumber.IdentityNumber}, {idnumber.BirthDate}, {idnumber.Gender}, {idnumber.Citizenship} {Environment.NewLine}");
                }
                else
                {
                    File2.Write($"{idnumber.IdentityNumber}, { String.Join("| ", idnumber.Reasons.ToArray())} {Environment.NewLine}");
                }

            }

            File.Close();
            File2.Close();

        }
        public List<IDNumberDetails> GetAll()
        {
            var valids = ReadValidFile();
            var inValids = InReadValidFile();

            List<IDNumberDetails> validations = new List<IDNumberDetails>();
            foreach (var item in valids.Split('\n'))
            {
                var model = item.Split(',');
                //string IdentityNumber, string BirthDate, string Gender, string Citizenship, string Status
                if (model.Length>2)
                     validations.Add(new IDNumberDetails(model[0], model[2], model[3], model[4], "valid"));
            }

            foreach (var item in inValids.Split('\n'))
            {
                var model = item.Split(',');
                if (model.Length > 1)
                {
                    validations.Add(new IDNumberDetails(model[0], "Invalid", new List<string>(model[1].Split('|'))));

                }
            }




            return validations;
        }

        private string MakeDir(string filename)
        {
            System.IO.Directory.CreateDirectory(@"C:\demodb");
            string path = @"C:\demodb\" + filename;
            return path;
        }
        private string GetDir(string filename)
        {
            return @"C:\demodb\" + filename;
        }
        private string ReadValidFile()
        {
            String line = String.Empty;

            try
            {

                using (StreamReader sr = new StreamReader(GetDir("valid.txt")))
                {
                     line = sr.ReadToEnd();
                }


            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            return line;


        }
        private string InReadValidFile()
        {
            String line = String.Empty;

            try
            {
                using (StreamReader sr = new StreamReader(GetDir("invalid.txt")))
                {
                     line = sr.ReadToEnd();
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            return line;
        }
    }
}
