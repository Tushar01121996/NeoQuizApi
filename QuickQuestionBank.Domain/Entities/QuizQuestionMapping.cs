using QuickQuestionBank.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuickQuestionBank.Domain.Entities {
    public class QuizQuestionMapping : BaseEntity
    {
        public Guid QuizId { get; set; }
        public Guid QuestionId { get; set; }
    }
}
