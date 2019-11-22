using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using StudyBuddy.Web.RazorPages.Logic;

namespace StudyBuddy.Web.RazorPages.Pages
{
    public class IndexModel : PageModel
    {
        private IHttpContextAccessor _httpContextAccessor;
        private ILogout _logout;
        public IndexModel(IHttpContextAccessor httpContextAccessor, ILogout logout)
        {
            _httpContextAccessor = httpContextAccessor;
            _logout = logout;
        }

        public void OnGet()
        {
            if (_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                _logout.LogoutFromAccount();
            }
        }
    }
}
