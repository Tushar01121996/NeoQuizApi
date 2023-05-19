using QuickQuestionBank.Domain.Entities;

namespace QuickQuestionBank.Domain.Entities
{
    public class Quiz : BaseEntity
    {
        public string QuizTitle { get; set; }
        public DateTime QuizExpiryDate { get; set; }
        public decimal QuizMarks { get; set; }
        public string QuestionsPerPage { get; set; }
        public string PassingCriteriaInPercentage { get; set; }
        public TimeSpan timeDuration { get; set; }
    }
}
