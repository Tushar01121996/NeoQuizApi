using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickQuestionBank.Domain.Entities {
    public interface IBaseEntity {
        Guid Id { get; set; }
        string CreatedBy { get; set; }
        DateTime CreatedDate { get; set; }
        bool IsDeleted { get; set; }
        string ModifiedBy { get; set; }
        DateTime? ModifiedDate { get; set; }
    }
}
