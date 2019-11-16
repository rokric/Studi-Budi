using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudyBuddy.Web.RazorPages.Logic;
using StudyBuddy.Web.RazorPages.Logic.Profile;
using System.ComponentModel.DataAnnotations;

namespace StudyBuddy.Web.RazorPages.Pages.TeacherPage
{
    public class TeacherProfileShowPasswordModel : PageModel
    {
        #region Properties
        [BindProperty, Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        #endregion


        private IGetPassword _getPassword;

        private int teacherID = CurrentUser.UserID;
        public string Msg;

        public TeacherProfileShowPasswordModel( IGetPassword getPassword)
        {
            _getPassword = getPassword;
        }

        public IActionResult OnPost()
        {
            try
            {
                if (_getPassword.IsPasswordMaches(Password.Trim(), teacherID))
                {
                    Msg = _getPassword.GetPasswordByID(teacherID);
                    return Page();
                }
                else
                {
                    Msg = "password is not correct";
                    return Page();
                }
            }
            catch (NullReferenceException)
            {
                Msg = "password can not be emty";
                return Page();
            }

        }

        public void OnGet()
        {

        }
    }
}