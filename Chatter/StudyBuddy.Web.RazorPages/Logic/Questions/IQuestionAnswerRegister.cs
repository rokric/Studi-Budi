﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyBuddy.Web.RazorPages.Logic
{
    public interface IQuestionAnswerRegister
    {
        Task RegisterAnswer(int questionID, string answer);
    }
}
