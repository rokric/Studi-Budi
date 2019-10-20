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
        public static bool IsLoginAccepted(string userName, string password, string profession)
        {
            userName = ChatServer.Encryptor.Encrypt(userName);
            password = ChatServer.Encryptor.Encrypt(password);
            ChatServer.DataWriter check = new ChatServer.DataWriter(userName, password, profession);
            return check.IsLoginAccepted();
        }
 
        public static bool CheckIfUserNameIsAvailable(string userName)
        {
            userName = ChatServer.Encryptor.Encrypt(userName);
            ChatServer.DataWriter check = new ChatServer.DataWriter(userName);
            return check.IsNickAvailable();
        }

        public static User ReturnUser(string userName, string password, string userType)
        {
            User user;
            if (userType.Equals("student"))
            {
                user = new Student(ChatServer.Encryptor.Encrypt(userName), ChatServer.Encryptor.Encrypt(password));
            }
            else
            {
                user = new Teacher(ChatServer.Encryptor.Encrypt(userName), ChatServer.Encryptor.Encrypt(password));
            }

            return user;
        }
        public static void AddData(string nick, string password, string profession)
        {
            nick = ChatServer.Encryptor.Encrypt(nick);
            password = ChatServer.Encryptor.Encrypt(password);
            ChatServer.DataWriter writer = new ChatServer.DataWriter(nick, password, profession);
            writer.Write();    
        }
        
        public static List<string> ReadSubjects()
        {
            ChatServer.DataWriter check = new ChatServer.DataWriter();
            return check.GetSubjects();
        }
        
        public static List<string> LoadTeachers()
        {
            ChatServer.DataWriter check = new ChatServer.DataWriter();
            return  check.GetTeachers();
        }
        
        public static void UpdateTeacherInfo(string title, string nick)
        {
            ChatServer.DataWriter check = new ChatServer.DataWriter(nick);
            check.InsertSubject(title);
        }

        public static List<string> GetSubjectsByTeacherName(string name)
        {
            ChatServer.DataWriter dataWriter = new ChatServer.DataWriter(name);
            return dataWriter.GetSubjectsByTeacherName();
        }
    }
}
