using QuickQuestionBank.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuickQuestionBank.Domain.Entities {
    public class QuizQuestionMapping : BaseEntity
    {
        public virtual Guid QuizId { get; set; }
        public virtual Guid QuestionId { get; set; }
    }
}
