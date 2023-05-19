using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickQuestionBank.Domain.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        public int Email { get; set; }
        public int Password { get; set; }
        public int Token { get; set; }
    }
}
