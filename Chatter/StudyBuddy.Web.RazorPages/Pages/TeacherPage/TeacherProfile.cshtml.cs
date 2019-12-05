using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudyBuddy.Web.RazorPages.Data;
using StudyBuddy.Web.RazorPages.Models;
using StudyBuddy.Web.RazorPages.Logic;
using StudyBuddy.Web.RazorPages.Logic.Profile;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace StudyBuddy.Web.RazorPages.Pages.TeacherPage
{
    public class TeacherProfileModel : PageModel
    {

        [BindProperty]
        public string NewPasswords { get; set; }

        [BindProperty]
        public string NewPasswords2 { get; set; }


        [BindProperty]
        public string OldPasswords { get; set; }

        [BindProperty]
        public string Name { get; set; }


        [TempData]
        public string Msgs { get; set; }

        private IHttpContextAccessor _httpContextAccessor;
        private readonly IUserInfoLoader _userInfoLoader;
        private ILoginChecker _loginchekers;
        private IProfile _getPasswords;
        private readonly ILoginChecker _logincheker;


        private int TeacherID { get; set; }

        public string TeacherName { get; set; }






        public TeacherProfileModel(IUserInfoLoader userInfoLoader, IProfile getPassword, ILoginChecker logincheker, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _getPasswords = getPassword;
            _logincheker = logincheker;
            _userInfoLoader = userInfoLoader;
            TeacherID = int.Parse(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
        }


        public async Task OnGetAsync()
        {
            TeacherName = await _userInfoLoader.GetUserNameById(TeacherID);
        }

        public async Task<IActionResult> OnPostAsync()
        {

            if(!_getPasswords.IsStringsMaches(NewPasswords,NewPasswords2) && !_getPasswords.IsStringsMaches(NewPasswords, OldPasswords))
            {
                Msgs = "bad data, try again";
                return RedirectToPage();
            }else if(!_getPasswords.IsPasswordMaches(OldPasswords,TeacherID))
            {
                Msgs = "bad data, try again";
                return RedirectToPage();
            }
            await _getPasswords.PasswordChange(NewPasswords, TeacherID);
            Msgs = "Password changed";
            return RedirectToPage();

        }

        public async Task<ActionResult> OnPostKazkasAsync()
        {

              if (_getPasswords.IsStringGood(OldPasswords) && _getPasswords.IsStringGood(Name) && _getPasswords.IsPasswordMaches(OldPasswords, TeacherID) )
              {//tikrina ar vardas tinkamas ir ar slaptazodis tinkamas

                  if (_logincheker.GetProfessionByUserName(Name) != null)
                  {
                      Msgs = "Bad Name";
                      return RedirectToPage();
                  }
                  else
                  {

                      await _getPasswords.NameChange(Name, TeacherID);
                        Msgs = "Name changed";
                        return RedirectToPage("/TeacherPage/TeacherProfile");
                  }
              }
              else
              {
                  Msgs = "Try again";
                  return RedirectToPage();
              }

        }
    }
}
