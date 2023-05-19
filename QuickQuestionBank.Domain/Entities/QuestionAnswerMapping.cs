using QuickQuestionBank.Domain.Entities;

namespace QuickQuestionBank.Domain.Entities {
    public class QuestionAnswerMapping : BaseEntity
    {
        public string OptionText { get; set; }
        public string IsCorrectAnswer { get; set; }
        public string SortOrder { get; set; }
    }
}
