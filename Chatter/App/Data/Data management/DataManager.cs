using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace App
{
    public static class DataManager
    {
        private static string filePath = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
        private static string registrationDataFileName = "\\Data\\Text Files\\userData.txt";
        private static string subjectsFileName = "\\Data\\Text Files\\subjectsData.txt";
        private static string conversationsFileName = "\\Data\\Text Files\\conversations.txt";

        public static bool IsLoginAccepted(string userName, string password, string profession)
        {
            userName = Encryptor.Encrypt(userName);
            password = Encryptor.Encrypt(password);
            DataWriter check = new DataWriter(userName, password, profession);
            return check.IsLoginAccepted();
        }
        // +
        public static string FindUser(string userName, string password)
        {
            string jsonValue = "";

            userName = Encryptor.Encrypt(userName);
            password = Encryptor.Encrypt(password);

            using (StreamReader file = new StreamReader(filePath + registrationDataFileName))
            {
                string line;

                while ((line = file.ReadLine()) != null)
                {
                    if (line.Contains("\"UserName\":" + "\"" + userName + "\"") &&
                        line.Contains("\"Password\":" + "\"" + password + "\""))
                    {
                        jsonValue = line;
                        break;
                    }
                }
                file.Close();
            }

            return jsonValue;
        }
        // -
        public static bool CheckIfUserNameIsAvailable(string userName)
        {
            userName = Encryptor.Encrypt(userName);
            DataWriter check = new DataWriter(userName);
            return check.IsNickAvailable();
        }
        // +
        public static void AddData(string nick, string password, string profession)
        {
            nick = Encryptor.Encrypt(nick);
            password = Encryptor.Encrypt(password);
            DataWriter writer = new DataWriter(nick, password, profession);
            writer.Write();    
        }
        // +
        public static List<string> ReadSubjects()
        {
            List<string> subjects = new List<string>();

            using (StreamReader file = new StreamReader(filePath + subjectsFileName))
            {
                string line;

                while ((line = file.ReadLine()) != null)
                {
                    subjects.Add(line);
                }
                file.Close();
            }

            return subjects;
        }
        //-
        public static List<string> LoadTeachers()
        {
            List<String> teachersListJson = new List<String>();

            using (StreamReader file = new StreamReader(filePath + registrationDataFileName))
            {
                string line;

                while ((line = file.ReadLine()) != null)
                {
                    if (line.Contains("\"Type\":" + "\"teacher\""))
                    {
                        teachersListJson.Add(line);
                    }
                }
                file.Close();
            }

            return teachersListJson;
        }
        //-
        //when teacher subject is changed, that teacher line in file is replaced
        public static void UpdateTeacherInfo(Teacher user)
        {
            try
            {
                string[] text = File.ReadAllLines(filePath + registrationDataFileName);
                File.Delete(filePath + registrationDataFileName);

                using (StreamWriter writer = new StreamWriter(filePath + registrationDataFileName, true))
                {
                    foreach (string line in text)
                    {
                        if (line.Contains("\"UserName\":\"" + user.UserName + "\""))
                        {
                            string json = JsonConvert.SerializeObject(user);
                            writer.WriteLine(json);
                        }
                        else
                        {
                            writer.WriteLine(line);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error with a text file: ", ex);
            }
        }
        //-
    }
}
