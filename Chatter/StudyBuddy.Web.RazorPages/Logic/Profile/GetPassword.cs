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
            return  Encryptor.Decrypt(_context.User.Where(u => u.Userid == ID).Select(u => u.Password).FirstOrDefault());
        }

        public bool IsPasswordMaches(string password, int ID)
        {
            Console.WriteLine(GetPasswordByID(ID) + "   " + password);
            if(GetPasswordByID(ID).Equals(password))
            {
                return true;
            }else
            {
                return false;
            }
            
        }

    }
}
