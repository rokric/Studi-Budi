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

        //constructor arguments are encrypted password and username
        public User(string userName)
        {
            this.UserName = userName;
        }
        public User(string userName, string password)
        {
            this.UserName = userName;
            this.Password = password;
        }

        public string UserName { get; set; }

        public string Password { get; set; }

        public abstract string Type { get;}
      
        public string GetDecryptedUserName()
        {
            return Encryptor.Decrypt(UserName);
        }
    }
}
