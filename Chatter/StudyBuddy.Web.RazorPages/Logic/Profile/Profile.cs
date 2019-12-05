using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudyBuddy.Web.RazorPages.Data;
using StudyBuddy.Web.RazorPages.Models;
using ChatServer;

namespace StudyBuddy.Web.RazorPages.Logic.Profile
{
    public class Profile : IProfile
    {

        private StudiBudiContext _context;
        public Profile(StudiBudiContext context)
        {
            _context = context;
        }

        public string GetPasswordByID(int ID)
        {
            return (_context.User.Where(u => u.Userid == ID).Select(u => u.Password).FirstOrDefault());
        }
        public string GetProfesionByID(int ID)
        {
            return (_context.User.Where(u => u.Userid == ID).Select(u => u.Profession).FirstOrDefault());
        }

        public string GetPasswordByname(string name)
        {

            return Encryptor.Decrypt(_context.User.Where(u => u.Nick == name).Select(u => u.Password).FirstOrDefault());
        }

        public bool IsPasswordMaches(string password, int id)
        {
             if (string.Equals(GetPasswordByID(id), Encryptor.Encrypt(password)))
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

        public bool IsStringGood(string password)
        {
            if(password==null)
            {
                return false;
            }else if(password.Length<=5)
            {
                return false;
            }

            return true;
        }

        public bool IsStringsMaches(string password, string password2)
        {
            if (password == null || password2 == null)
            {
                return false;
            }
            else if (password.Equals(password2) && IsStringGood(password))
            {
                return true;
            }
            return false;
        }


    }
}

