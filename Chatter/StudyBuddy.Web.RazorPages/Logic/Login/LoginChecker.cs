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
        private readonly IAccessDeniedHandler _accessDeniedHandler;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LoginChecker(StudiBudiContext context, IHttpContextAccessor httpContextAccessor, IAccessDeniedHandler accessDeniedHandler)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _accessDeniedHandler = accessDeniedHandler;
        }

        public int GetUserIDByUserName(string username) =>
            _context.User.Where(u => u.Nick == Encryptor.Encrypt(username)).Select(u => u.Userid).FirstOrDefault();

        //returns 0 if user is student or teacher
        //returns 1 if user is admin
        //returns 2 if user is banned
        //return -1 if login failed
        public async Task<int> IsLogCorrect(string username, string password, string profession)
        {
            if (UserExists(username))
            {
                if (password == GetPasswordByUserName(username))
                {
                    if(profession == GetProfessionByUserName(username))
                    {
                        if (_accessDeniedHandler.IsAccessDenied(GetUserIDByUserName(username)))
                        {
                            return 2;
                        }

                        await CreateCookie(username);
                        return 0;
                    }
                    else if(GetProfessionByUserName(username) == "admin")
                    {
                        if (_accessDeniedHandler.IsAccessDenied(GetUserIDByUserName(username)))
                        {
                            return 2;
                        }

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
