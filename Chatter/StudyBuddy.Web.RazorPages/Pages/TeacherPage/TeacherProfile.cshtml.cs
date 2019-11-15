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

        #region Properties
        [BindProperty, Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        #endregion


        private readonly IUserInfoLoader _userInfoLoader;
        private  IGetPassword _getPassword;

        private int teacherID= CurrentUser.UserID;
        public string TeacherName;
        public string Msg;



        public TeacherProfileModel(IUserInfoLoader userInfoLoader, IGetPassword getPassword)
        {
            _userInfoLoader = userInfoLoader;
            _getPassword = getPassword;
        }
       
        public IActionResult OnPost()
        {
            if (_getPassword.IsPasswordMaches(Password.Trim(),teacherID))
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

        public async Task OnGet()
        {
            TeacherName = await _userInfoLoader.GetUserNameById(teacherID);
        }
    }
}
