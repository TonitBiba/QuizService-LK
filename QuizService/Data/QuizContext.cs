namespace QuizService.Data {
    using Microsoft.EntityFrameworkCore;

    public class QuizContext : DbContext {
        public QuizContext(DbContextOptions<QuizContext> options) : base(options) {

        }

        public DbSet<Quiz> Quiz { get; set; }
        public DbSet<Question> Question { get; set; }
        public DbSet<Option> Option { get; set; }
        public DbSet<QuestionType> QuestionType { get; set; }
        public DbSet<Log> Log { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {

        }
    }
}
