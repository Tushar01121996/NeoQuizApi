using QuickQuestionBank.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace QuickQuestionBank.Domain.Entities
{
    public class ShareQuiz
    {
        [Key]
        public int Id { get; set; }
        public Guid QuizId { get; set; }
        public string Email { get; set; }
        public string Link { get; set; }
        public DateTime CreatedDate { get; set; }
        //public DateTime? ModifiedDate { get; set; }
        //public DateTime? DeletedDate { get; set; }
        public string CreatedBy { get; set; }
        //public string? ModifiedBy { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
