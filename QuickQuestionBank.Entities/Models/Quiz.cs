namespace QuickQuestionBank.Models
{
    public class Quiz
    {
        public int QuizId { get; set; }
        public string QuizTitle { get; set; }
        public DateTime QuizExpiryDate { get; set; }
        public decimal QuizMarks { get; set; }
        public string QuestionsPerPage { get; set; }
        public string Passing_CriteriaInPercentage { get; set; }
        public bool IsActive { get; set; }
        public DateTime CeatedOn { get; set; }
        public DateTime CeatedBy { get; set; }
        public DateTime UpdateOn { get; set; }
        public DateTime UpdateBy { get; set; }
    }
}
