using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        private IPoints _points;
        private int teacherID;
        public int TotalPoints { get; set; }
        public TeacherPointsModel(ITeacherPoints teacherPoints, IPoints points)
        {
            _teacherPoints = teacherPoints;
            _points = points;
            teacherID = CurrentUser.UserID;
        }

        public IList<Question> Question { get;set; }

        public async Task OnGetAsync()
        {
            Question = await _teacherPoints.GetHistoryByTeacherID(teacherID);
            TotalPoints = await _points.GetTotalPoints(teacherID);
        }
    }
}
