using QuickQuestionBank.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace QuickQuestionBank.Domain.Entities {
    public class QuestionOptionViewModel : BaseEntity
    {
        public Guid QuizId { get; set; }
        public Guid QuestionId { get; set; }
        public Guid QuestionTypeId { get; set; }
        public string QuestionText { get; set; }
        public string SortOrder { get; set; }
        public List<QuestionAnswerMapping> Options { get; set; }

    }
}
