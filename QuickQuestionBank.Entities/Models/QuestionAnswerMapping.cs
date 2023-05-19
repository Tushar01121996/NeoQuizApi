namespace QuickQuestionBank.Models
{
    public class QuestionAnswerMapping
    {
        public int QuestionMappingId { get; set; }
        public string OptionText { get; set; }
        public string IsCorrectAnswer { get; set; }
        public string SortOrder { get; set; }
        public DateTime Createon { get; set; }
        public DateTime CeatedBy { get; set; }
        public DateTime UpdateOn { get; set; }
        public DateTime UpdateBy { get; set; }
        public DateTime DeletedOn { get; set; }
    }
}
