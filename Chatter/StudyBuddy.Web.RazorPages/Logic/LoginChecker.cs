using ChatServer;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using StudyBuddy.Web.RazorPages.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace StudyBuddy.Web.RazorPages.Logic
{
    public class LoginChecker : ILoginChecker
    {
        private readonly StudiBudiContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LoginChecker(StudiBudiContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public int GetUserIDByUserName(string username) =>
            _context.User.Where(u => u.Nick == Encryptor.Encrypt(username)).Select(u => u.Userid).FirstOrDefault();

        //returns 0 if user is student or teacher
        //returns 1 if user is admin
        //return -1 if login failed
        public async Task<int> IsLogCorrect(string username, string password, string profession)
        {
            if (UserExists(username))
            {
                if (password == GetPasswordByUserName(username))
                {
                    if(profession == GetProfessionByUserName(username))
                    {
                        await CreateCookie(username);
                        return 0;
                    }
                    else if(GetProfessionByUserName(username) == "admin")
                    {
                        await CreateCookie(username);
                        return 1;
                    }
                    
                }
            }

            return -1;
        }

        private async Task CreateCookie(string username)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, GetUserIDByUserName(username).ToString())
            };

            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
            };

            await AuthenticationHttpContextExtensions.SignInAsync(
                _httpContextAccessor.HttpContext, CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);
        }

        private bool UserExists(string username)
        {
            return _context.User.Where(u => u.Nick == Encryptor.Encrypt(username)).Select(u => u.Password).FirstOrDefault() != null;
        }
        private string GetPasswordByUserName(string username) =>
            Encryptor.Decrypt(_context.User.Where(u => u.Nick == Encryptor.Encrypt(username)).Select(u => u.Password).FirstOrDefault());
        public string GetProfessionByUserName(string username) =>
            _context.User.Where(u => u.Nick == Encryptor.Encrypt(username)).Select(u => u.Profession).FirstOrDefault();
       
        

       


    }
}
