using Microsoft.EntityFrameworkCore;
using StudyBuddy.Web.RazorPages.Data;
using StudyBuddy.Web.RazorPages.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyBuddy.Web.RazorPages.Logic
{
    public class QuestionAnswerRegister : IQuestionAnswerRegister
    {
        private StudiBudiContext _context;
        public QuestionAnswerRegister(StudiBudiContext context)
        {
            _context = context;
        }

        public async Task RegisterAnswer(int questionID, string answer)
        {
            if (string.IsNullOrEmpty(answer))
            {
                throw new ArgumentException("answer cannot be empty");
            }

            Question question = await FindQuestionById(questionID);
            _context.Attach(question);
            question.Status = 1;
            question.Answer = answer;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException exc)
            {
                if (!QuestionExists(questionID))
                {
                    Console.WriteLine("Error happened while saving answer. Question does not exist in a database");
                    Console.WriteLine(exc.Message);
                }
                else
                {
                    throw;
                }
            }
            
        }

        private async Task<Question> FindQuestionById(int questionID)
        {
            IList<Question> questions = await _context.Question.ToListAsync();
            Question question = questions.Where(q => q.QuestionID == questionID).FirstOrDefault();

            return question;
        }

        private bool QuestionExists(int questionID)
        {
            if(_context.Question.Any(q => q.QuestionID == questionID))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
