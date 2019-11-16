using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudyBuddy.Web.RazorPages.Logic;
using StudyBuddy.Web.RazorPages.Logic.Profile;

namespace StudyBuddy.Web.RazorPages.Pages.TeacherPage
{
    public class TeacherProfileChangePasswordModel : PageModel
    {


        #region Properties
        [BindProperty, Required]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

 
        [BindProperty, Required]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }
        #endregion


        private IGetPassword _getPassword;

        private int teacherID = CurrentUser.UserID;
        public string Msg;

        public TeacherProfileChangePasswordModel(IGetPassword getPassword)
        {
            _getPassword = getPassword;
        }

        public void OnGet()
        {
        }



        public async Task<IActionResult> OnPost()
        {
            if(_getPassword.IsPasswordGood(NewPassword)&& _getPassword.IsPasswordGood(OldPassword) && _getPassword.IsPasswordMaches(OldPassword,teacherID))
            {
                await _getPassword.PasswordChange(NewPassword, teacherID);
                return RedirectToPage("/TeacherPage/TeacherProfile");
            }
            else
            {
                Msg = "bad data, try again";
                return Page();
            }
            
        }
    }
}