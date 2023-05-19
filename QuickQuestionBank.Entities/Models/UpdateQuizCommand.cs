using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickQuestionBank.Entities.Models
{
    public class UpdateQuizCommand
    {
        public int QuizId { get; set; }
        public string QuizTitle { get; set; }
        public DateTime QuizExpiryDate { get; set; }
        public decimal QuizMarks { get; set; }
        public string QuestionsPerPage { get; set; }
        public string PassingCriteriaInPercentage { get; set; }
        public bool IsActive { get; set; }
    }
}
