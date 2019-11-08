using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace StudyBuddy.Web.RazorPages.Pages
{
    public class LoggedModel : PageModel
    {
        public string Username;
        public void OnGet()
        {
           Username = HttpContext.Session.GetString("username");
        }
    }
}