namespace QuickQuestionBank.Models
{
    public class QuestionType
    {
		public int QuestionTypeId { get; set; }
		public string QuestionTypenew { get; set; }
		public DateTime Createon { get; set; }
        public DateTime CeatedBy { get; set; }
        public DateTime UpdateOn { get; set; }
        public DateTime UpdateBy { get; set; }
        public DateTime DeletedOn { get; set; }
        public int UserId { get; set; }
      
    }
}
