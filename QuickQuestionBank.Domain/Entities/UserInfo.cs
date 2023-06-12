using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickQuestionBank.Domain.Entities
{
    public class UserInfo:BaseEntity
    {
        public string UserName { get; set; }

        public string Email { get; set; }

    }
}
