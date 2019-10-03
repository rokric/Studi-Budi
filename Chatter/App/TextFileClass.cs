using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    public static class TextFileClass
    {
        public static bool CheckIfUserExists(string data)
        {
            string filePath = @".\data.txt";
            bool found = false;

            using (StreamReader file = new StreamReader(filePath))
            {
                string line;

                while ((line = file.ReadLine()) != null)
                {
                    if(line == data)
                    {
                        found = true;
                        break;
                    }
                }
                file.Close();
            }

            return found;
        }

        public static bool CheckIfUserNameIsAvailable(string userName)
        {
            string filePath = @".\data.txt";
            bool found = true;

            using (StreamReader file = new StreamReader(filePath))
            {
                string line;

                while ((line = file.ReadLine()) != null)
                {
                    string[] data = line.Split(',');

                    if (userName == data[0])
                    {
                        found = false;
                        break;
                    }
                }
                file.Close();
            }

            return found;
        }

        public static void AddData(string data)
        {
            string filePath = @".\data.txt";

            try
            {
                using (StreamWriter file = new StreamWriter(filePath, true))
                {
                    file.WriteLine(data);
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error with a text file: ", ex);
            }
        }
    }
}
