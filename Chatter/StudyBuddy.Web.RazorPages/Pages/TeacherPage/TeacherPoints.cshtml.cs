using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudyBuddy.Web.RazorPages.Data;
using StudyBuddy.Web.RazorPages.Logic;
using StudyBuddy.Web.RazorPages.Logic.Ratings;
using StudyBuddy.Web.RazorPages.Models;

namespace StudyBuddy.Web.RazorPages.Pages.TeacherPage
{
    public class TeacherPointsModel : PageModel
    {
        private ITeacherPoints _teacherPoints;
        private IHttpContextAccessor _httpContextAccessor;
        private IPoints _points;
        private int teacherID;
        public int TotalPoints { get; set; }
        public TeacherPointsModel(ITeacherPoints teacherPoints, IPoints points, IHttpContextAccessor httpContextAccessor)
        {
            _teacherPoints = teacherPoints;
            _httpContextAccessor = httpContextAccessor;
            _points = points;
        }

        public IList<Question> Question { get;set; }

        public async Task OnGetAsync()
        {
            teacherID = int.Parse(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            Question = await _teacherPoints.GetHistoryByTeacherID(teacherID);
            TotalPoints = await _points.GetTotalPoints(teacherID);
        }
    }
}
