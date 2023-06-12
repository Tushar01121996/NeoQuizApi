using QuickQuestionBank.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickQuestionBank.Domain.Entities
{
    public class ShareUserQuiz: BaseEntity
    {
        public Guid? UserId { get; set; }

        public Guid? QuizId { get; set; }

        public string Link { get; set; }

    }
}

