namespace QuickQuestionBank.Models
{
    public class QuizQuestion
    {
        public int QuestionId { get; set; }
        public string QuestionText { get; set; }
        public int QuestionTypeId { get; set; }
        public bool IsActive { get; set; }
        public decimal Marks { get; set; }
        public string SortOrder { get; set; }
        public string ComplexityLevel { get; set; }
        public DateTime Createon { get; set; }
        public DateTime CeatedBy { get; set; }
        public DateTime UpdateOn { get; set; }
        public DateTime UpdateBy { get; set; }
        public DateTime DeletedOn { get; set; }
	
    }
}
