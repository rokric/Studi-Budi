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

        #region Done Methods
        public static bool IsLoginAccepted(string userName, string password, string profession)
        {
            userName = Encryptor.Encrypt(userName);
            password = Encryptor.Encrypt(password);
            DataWriter check = new DataWriter(userName, password, profession);
            return check.IsLoginAccepted();
        }
        // +
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
        #endregion
        #region Not Done Methods
        public static List<string> ReadSubjects()
        {
            DataWriter check = new DataWriter();
            return check.GetSubjects();
        }
        //+
        public static List<string> LoadTeachers()
        {
            DataWriter check = new DataWriter();
            return  check.GetTeachers();
        }
        //-
        //when teacher subject is changed, that teacher line in file is replaced
        public static void UpdateTeacherInfo(string title, string nick)
        {
            DataWriter check = new DataWriter(Encryptor.Encrypt(nick));
            check.InsertSubject(title);
        }
        //+
        #endregion
    }
}
