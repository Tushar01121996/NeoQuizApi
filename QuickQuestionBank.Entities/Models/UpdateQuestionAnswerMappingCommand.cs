using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickQuestionBank.Entities.Models
{
    public class UpdateQuestionAnswerMappingCommand
    {
        public int QuestionMappingId { get; set; }
        public string OptionText { get; set; }
        public bool IsCorrectAnswer { get; set; }
        public string SortOrder { get; set; }
    }
}
