using Microsoft.EntityFrameworkCore;
using StudyBuddy.Web.RazorPages.Data;
using StudyBuddy.Web.RazorPages;
using StudyBuddyLogic;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyBuddy.Web.RazorPages.Logic
{
    public class UserInfoLoader : IUserInfoLoader
    {
        private StudiBudiContext _context;
        public UserInfoLoader(StudiBudiContext context)
        {
            _context = context;
        }

        public async Task<string> GetEncryptedUserNameById(int id)
        {
            string userName;
            IList<Models.User> students = await _context.User.ToListAsync();
            userName = students.Where(u => u.Userid == id).Select(u => u.Nick).FirstOrDefault();
            return userName;
        }

        public async Task<string> GetUserNameById(int id)
        {
            string userName;
            IList<Models.User> students = await _context.User.ToListAsync();
            userName = students.Where(u => u.Userid == id).Select(u => u.Nick).FirstOrDefault();
            userName = Encryptor.Decrypt(userName);
            return userName;
        }
    }
}
