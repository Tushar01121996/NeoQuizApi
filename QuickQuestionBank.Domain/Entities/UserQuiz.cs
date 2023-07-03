using QuickQuestionBank.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickQuestionBank.Domain.Entities
{
    public class UserQuiz: BaseEntity
    {
        public Guid? UserId { get; set; }

        public Guid? QuizId { get; set; }
        public bool isAttempted { get; set; }
        public string TimeDuration { get; set; }

        [NotMapped]
        public string Link { get; set; }

    }
}

