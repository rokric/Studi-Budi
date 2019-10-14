using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace App
{

    public abstract class User : IUser
    {
        private string userName;
        private string password;
        //constructor arguments are encrypted password and username
        [JsonConstructor]
        public User(string userName, string password)
        {
            this.userName = userName;
            this.password = password;
        }

        public string UserName {
            get { return userName; }
            set { userName = value; }
        }

        public string Password 
        {
            get { return password; }
            set { password = value; }
        }

        public abstract string Type { get;}
      
        public string GetDecryptedUserName()
        {
            return Encryptor.Decrypt(UserName);
        }
    }
}
