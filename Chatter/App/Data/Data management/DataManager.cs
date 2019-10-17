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
        public static string filePath = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()));

        public static bool IsLoginAccepted(string userName, string password, string profession)
        {
            userName = Encryptor.Encrypt(userName);
            password = Encryptor.Encrypt(password);
            DataWriter check = new DataWriter(userName, password, profession);
            return check.IsLoginAccepted();
        }
 
        public static bool CheckIfUserNameIsAvailable(string userName)
        {
            userName = Encryptor.Encrypt(userName);
            DataWriter check = new DataWriter(userName);
            return check.IsNickAvailable();
        }
      
        public static void AddData(string nick, string password, string profession)
        {
            nick = Encryptor.Encrypt(nick);
            password = Encryptor.Encrypt(password);
            DataWriter writer = new DataWriter(nick, password, profession);
            writer.Write();    
        }
        
        public static List<string> ReadSubjects()
        {
            DataWriter check = new DataWriter();
            return check.GetSubjects();
        }
        
        public static List<string> LoadTeachers()
        {
            DataWriter check = new DataWriter();
            return  check.GetTeachers();
        }
        
        public static void UpdateTeacherInfo(string title, string nick)
        {
            DataWriter check = new DataWriter(nick);
            check.InsertSubject(title);
        }

        public static List<string> GetSubjectsByTeacherName(string name)
        {
            DataWriter dataWriter = new DataWriter(name);
            return dataWriter.GetSubjectsByTeacherName();
        }
    }
}
