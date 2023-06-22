using QuickQuestionBank.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuickQuestionBank.Domain.Entities {
    public class QuizQuestionMapping : BaseEntity
    {
        public Guid QuizId { get; set; }
        public Guid QuestionId { get; set; }
        [NotMapped]
        public string QuestionText { get; set; }
        [NotMapped]
        public string SortOrder { get; set; }
        [NotMapped]
        public string QuestionTypeId { get; set; }
        [NotMapped]
        public Guid OptionId { get; set; }
        [NotMapped]
        public string OptionText { get; set; }
        [NotMapped]
        public string IsCorrectAnswer { get; set; }
        [NotMapped]
        public int OptionSortOrder { get; set; }


    }
}
