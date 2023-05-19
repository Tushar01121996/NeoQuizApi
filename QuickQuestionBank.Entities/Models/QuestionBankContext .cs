using Microsoft.EntityFrameworkCore;

namespace QuickQuestionBank.Models
{
    public partial class QuestionBankContext : DbContext
    {
        public QuestionBankContext()
        {
        }

        public QuestionBankContext(DbContextOptions<QuestionBankContext> options)
            : base(options)
        {
        }

        public virtual DbSet<UserAdmin> UserAdmin { get; set; }
        public virtual DbSet<QuestionAnswerMapping> QuestionAnswerMapping { get; set; }
        public virtual DbSet<QuestionType> QuestionType { get; set; }
        public virtual DbSet<Quiz> Quiz { get; set; }
        public virtual DbSet<QuizQuestion> QuizQuestion { get; set; }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
