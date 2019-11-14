using ChatServer;
using StudyBuddy.Web.RazorPages.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyBuddy.Web.RazorPages.Logic
{
    public class LoginChecker : ILoginChecker
    {
        private readonly StudiBudiContext _context;

        public LoginChecker(StudiBudiContext context)
        {
            _context = context;
        }

        public int GetUserIDByUserName(string username) =>
            _context.User.Where(u => u.Nick == Encryptor.Encrypt(username)).Select(u => u.Userid).FirstOrDefault();

        public bool IsLogCorrect(string username, string password, string profession)
        {
            if (UserExists(username))
            {
                if (password == GetPasswordByUserName(username) && profession == GetProfessionByUserName(username))
                    return true;
                else return false;
            }
            else return false;
        } 
        private bool UserExists(string username)
        {
            return _context.User.Where(u => u.Nick == Encryptor.Encrypt(username)).Select(u => u.Password).FirstOrDefault() != null;
        }
        private string GetPasswordByUserName(string username) =>
            Encryptor.Decrypt(_context.User.Where(u => u.Nick == Encryptor.Encrypt(username)).Select(u => u.Password).FirstOrDefault());
        private string GetProfessionByUserName(string username) =>
            _context.User.Where(u => u.Nick == Encryptor.Encrypt(username)).Select(u => u.Profession).FirstOrDefault();

       


    }
}
