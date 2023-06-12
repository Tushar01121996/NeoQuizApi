using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickQuestionBank.Domain.Entities
{
    public class SubTopics : BaseEntity
    {
        public Guid? TopicId { get; set; }

        public string SubTopicName { get; set; }

        [NotMapped]
        public string TopicName { get; set; }
    }
}

