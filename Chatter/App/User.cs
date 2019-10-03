using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    public interface IUser
    {
        string UserName { get; set; }
        string Password { get; set; }

        string EncryptedUserName { get; }
    }

    public abstract class User : IUser
    {
        private Encryptor encryptor;
        private string username;
        private string password; 

        public User(string userName, string password)
        {
            encryptor = new Encryptor();
            UserName = userName;
            Password = password;
        }

        public string UserName
        {
            get { return encryptor.Encrypt(username); }
            set { username = value; }
        }

        public string Password
        {
            get { return encryptor.Encrypt(password); }
            set { password = value; }
        }

        public string EncryptedUserName
        {
            get { return username; }
        }
    }

    public class Student : User
    {
        public Student(string userName, string password):base(userName, password)
        {
            
        }

        public override string ToString()
        {
            return UserName + "," + Password + "," + "student";
        }
    }

    public class Teacher : User
    {
        public Teacher(string userName, string password) : base(userName, password)
        {

        }

        public override string ToString()
        {
            return UserName + "," + Password + "," + "teacher";
        }
    }  
}
