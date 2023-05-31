using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QuickQuestionBank.Domain.Entities;

namespace QuickQuestionBank.Domain {
    public class QuickQuestionDbContext : IdentityDbContext<User, Role, string,
     IdentityUserClaim<string>, UserRole, IdentityUserLogin<string>,
     IdentityRoleClaim<string>, IdentityUserToken<string>> {

        public QuickQuestionDbContext(DbContextOptions<QuickQuestionDbContext> dbOptions) 
            : base(dbOptions) { }

        public DbSet<Quiz> Quiz { get; set; }
        public DbSet<QuizQuestion> QuizQuestions { get; set; }
        public DbSet<QuestionType> QuestionTypes { get; set; }
        public DbSet<QuestionAnswerMapping> QuestionAnswerMapping { get; set; }
        public DbSet<QuizQuestionMapping> QuizQuestionMapping { get; set; }
        public DbSet<ShareQuiz> ShareQuizes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            foreach (var type in modelBuilder.Model.GetEntityTypes()) {
                if (typeof(IBaseEntity).IsAssignableFrom(type.ClrType))
                    modelBuilder.SetSoftDeleteFilter(type.ClrType);
            }
            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges() {
            UpdateSoftDeleteStatuses();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default) {
            UpdateSoftDeleteStatuses();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void UpdateSoftDeleteStatuses() {
            foreach (var entry in ChangeTracker.Entries()) {
                switch (entry.State) {
                    case EntityState.Added:
                        entry.CurrentValues["IsDeleted"] = false;
                        break;
                    case EntityState.Deleted:  // remove
                        entry.State = EntityState.Modified;
                        entry.CurrentValues["IsDeleted"] = true;
                        break;
                }
            }
        }

    }
}
