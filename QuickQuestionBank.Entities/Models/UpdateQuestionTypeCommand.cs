using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickQuestionBank.Entities.Models
{
    public class UpdateQuestionTypeCommand
    {
        public int QuestionTypeId { get; set; }
        public string QuestionTypenew { get; set; }
    }
}
