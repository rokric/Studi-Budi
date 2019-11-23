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



        private readonly IUserInfoLoader _userInfoLoader;
        private ILoginChecker _loginchekers;
        private IProfile _getPasswords;
        private readonly ILoginChecker _logincheker;
        private readonly int TeacherID = CurrentUser.UserID;
        public string Msgs;

        public string TeacherName;
        public string TeacherPassword;




        public TeacherProfileModel(IUserInfoLoader userInfoLoader, IProfile getPassword, ILoginChecker logincheker)
        {
            _getPasswords = getPassword;
            _logincheker = logincheker;
            _userInfoLoader = userInfoLoader;
        }


        public async Task OnGet()
        {
            TeacherPassword = _getPasswords.GetPasswordByID(TeacherID);
            TeacherName = await _userInfoLoader.GetUserNameById(TeacherID);
        }

        public async Task<IActionResult> OnPost()
        {

            //reikia padaryti
            if (_getPasswords.IsPasswordGood(NewPasswords) && _getPasswords.IsPasswordGood(OldPasswords) && _getPasswords.IsPasswordMaches(OldPasswords, TeacherID))
            {
                await _getPasswords.PasswordChange(NewPasswords, TeacherID);
                return RedirectToPage("/TeacherPage/TeacherProfile");
            }
            else
            {
                Msgs = "bad data, try again";
                return RedirectToPage("/TeacherPage/TeacherProfile");

            }

        }

        public async Task<ActionResult> OnPostKazkasAsync()
        {
            //return RedirectToPage("/TeacherPage/TeacherProfileChangeName");
            // reikia dar padaryti
            if (_getPasswords.IsPasswordGood(OldPasswords) && _getPasswords.IsPasswordGood(Name) && _getPasswords.IsPasswordMaches(OldPasswords, TeacherID))
            {

                if (_loginchekers.GetProfessionByUserName(Name) != null)
                {
                    Msgs = "Bad Name";
                    return Page();
                }
                else
                {
                    // pakeisti name
                    await _getPasswords.NameChange(Name, TeacherID);
                    return RedirectToPage("/TeacherPage/TeacherProfile");
                }
            }
            else
            {
                Msgs = "bad data, try again";
                return Page();
            }
        }
    }
}
