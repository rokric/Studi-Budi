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


        private IHttpContextAccessor _httpContextAccessor;
        private readonly IUserInfoLoader _userInfoLoader;
        private ILoginChecker _loginchekers;
        private IProfile _getPasswords;
        private readonly ILoginChecker _logincheker;


        private int TeacherID { get; set; }
        public string Msgs;

        public string TeacherName { get; set; }

        public string TeacherNameEn { get;  set; }

        public string TeacherPassword;




        public TeacherProfileModel(IUserInfoLoader userInfoLoader, IProfile getPassword, ILoginChecker logincheker, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _getPasswords = getPassword;
            _logincheker = logincheker;
            _userInfoLoader = userInfoLoader;
        }


        public async Task OnGet()
        {
            TeacherID = int.Parse(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
           // reiks istrinti
            TeacherPassword = _getPasswords.GetPasswordByID(TeacherID);
            TeacherName = await _userInfoLoader.GetUserNameById(TeacherID);
            TeacherNameEn = await _userInfoLoader.GetEncryptedUserNameById(TeacherID);

        }

        public IActionResult OnPost()
        {
            Console.WriteLine(TeacherID+"   "+ TeacherNameEn + "asdasssssssssssssssssssssssssssssssssssssssss "+TeacherName);
            //reikia padaryti
            if (_getPasswords.IsPasswordGood(NewPasswords) && _getPasswords.IsPasswordGood(NewPasswords2) && _getPasswords.IsPasswordsMaches(NewPasswords, NewPasswords2))
            {
                if (_getPasswords.IsPasswordGood(OldPasswords) && _getPasswords.IsPasswordMaches(OldPasswords, TeacherNameEn))
                {
                    Console.WriteLine(TeacherID + "asdasssssssssssssssssssssssssssssssssssssssss");
                    // await _getPasswords.PasswordChange(NewPasswords, TeacherID);
                    return RedirectToPage("/TeacherPage/TeacherProfileChangePassword");
                }
                else
                {
                    Msgs = "bad data, try again";
                    return RedirectToPage("/TeacherPage/TeacherProfile");

                }

            }
            else
            {
                Msgs = "bad data, try again";
                return RedirectToPage("/TeacherPage/TeacherProfile");

            }


            //kaip parasyti bad data try again

        }

        public async Task<ActionResult> OnPostKazkasAsync()
        {
            //return RedirectToPage("/TeacherPage/TeacherProfileChangeName");
            // reikia dar padaryti
            //not working
            if (_getPasswords.IsPasswordGood(OldPasswords) && _getPasswords.IsPasswordGood(Name) && _getPasswords.IsPasswordMaches(OldPasswords, TeacherName))
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
