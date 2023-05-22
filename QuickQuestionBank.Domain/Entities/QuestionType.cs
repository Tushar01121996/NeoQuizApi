using QuickQuestionBank.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuickQuestionBank.Domain.Entities {
    public class QuestionType : BaseEntity
    {
		public string QuestionTypeName { get; set; }
        //public string UserId { get; set; }

        //[ForeignKey(nameof(UserId))]
        //public User User { get; set; }

    }
}
