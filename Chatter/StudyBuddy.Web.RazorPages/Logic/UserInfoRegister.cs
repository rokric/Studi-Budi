using ChatServer;
using StudyBuddy.Web.RazorPages.Data;
using StudyBuddy.Web.RazorPages.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyBuddy.Web.RazorPages.Logic
{
    public class UserInfoRegister : IUserInfoRegister
    {
        private readonly StudiBudiContext _context;
        private Action<string, string, string> HandleNewUser;

        public UserInfoRegister (StudiBudiContext context)
        {
            _context = context;
        }

        public void WriteUserInfo(string username, string password, string profession)
        {
            HandleNewUser = Create;
            HandleNewUser.Invoke(username, password, profession);
        }

        private void Create(string username, string password, string profession)
        {

                User user = new User
                {
                    Nick = Encryptor.Encrypt(username),
                    Password = Encryptor.Encrypt(password),
                    Profession = profession,

                };

                _context.Add(user);
                _context.SaveChanges();
        }
    }
}
