using Microsoft.AspNetCore.Identity;

namespace QuickQuestionBank.Domain.Entities {
    public class Role : IdentityRole {
        public bool IsDeleted { get; set; } = false;
    }

    public class UserRole : IdentityUserRole<string> {
        public bool IsDeleted { get; set; } = false;
    }
}
