using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudyBuddy.Web.RazorPages.Data;
using StudyBuddy.Web.RazorPages.Models;
using ChatServer;

namespace StudyBuddy.Web.RazorPages.Logic.Profile
{
    public class GetPassword : IGetPassword
    {

        private StudiBudiContext _context;
        public GetPassword(StudiBudiContext context)
        {
            _context = context;
        }

        public string GetPasswordByID(int ID)
        {
            // return "rrrrrrrrrrrppppl";
            return Encryptor.Decrypt(_context.User.Where(u => u.Userid == ID).Select(u => u.Password).FirstOrDefault());
        }

        public bool IsPasswordMaches(string password, int ID)
        {
            Console.WriteLine(GetPasswordByID(ID) + "   " + password);
            if (string.Equals(GetPasswordByID(ID), password))//GetPasswordByID(ID).Equals(password))
            {
                return true;
            } else
            {
                return false;
            }

        }

        public User FindUserById(int ID)
        {
            IList<User> users = _context.User.ToList();
            User user = users.Where(q => q.Userid == ID).FirstOrDefault();
            return user;
        }

        public async Task PasswordChange( string New, int Id)
        {
            User user = FindUserById(Id);
            _context.Attach(user);
            user.Password = Encryptor.Encrypt(New);
            await _context.SaveChangesAsync();

        }
        public async Task NameChange(string New, int Id)
        {
            User user = FindUserById(Id);
            _context.Attach(user);
            user.Nick = Encryptor.Encrypt(New);
            await _context.SaveChangesAsync();

        }

        public bool IsPasswordGood(string? password)
        {
            if(password==null)
            {
                return false;
            }else if(password.Length<4)
            {
                return false;
            }

            return true;
        }

    }
}

