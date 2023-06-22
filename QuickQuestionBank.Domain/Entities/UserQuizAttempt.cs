using QuickQuestionBank.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickQuestionBank.Domain.Entities
{
    public class UserQuizAttempt : BaseEntity
    {
        public Guid? UserId { get; set; }
        public Guid? QuizId { get; set; }
        public Guid? QuestionId { get; set; }
        public Guid? OptionId { get; set; }

    }
}

