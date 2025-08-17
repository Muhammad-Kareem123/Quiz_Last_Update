using Exam_Api_v2.Models;
using Microsoft.EntityFrameworkCore;

namespace Exam_Api_v2.Data
{
    public class AppDB_Context:DbContext
    {
        public AppDB_Context(DbContextOptions<AppDB_Context> options) : base(options) { }
        public DbSet<Account> accounts { get; set; }
        public DbSet<Exam> exams { get; set; }
        public DbSet<Exam_QuestionBank> exam_QuestionBanks { get; set; }
        public DbSet<Fill_In_Gaps> fill_In_Gaps{ get; set; }
        public DbSet<Login> logins{ get; set; }
        public DbSet<MCQ_Options> mCQ_Options{ get; set; }
        public DbSet<Question_Bank> questionBanks { get; set; }
        public DbSet<QuestionType> questionTypes{ get; set; }
        public DbSet<Roles> roles{ get; set; }
        public DbSet<Status> statuses{ get; set; }
        public DbSet<Student_ExamQB> student_ExamQBs{ get; set; }
        public DbSet<TrueOrFalse> trueOrFalses{ get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ============================
            // Account ↔ Status (M:1)
            // ============================
            modelBuilder.Entity<Account>()
                .HasOne(a => a.Status)
                .WithMany(s => s.Accounts)
                .HasForeignKey(a => a.Status_ID)
                .OnDelete(DeleteBehavior.Restrict);

            // ============================
            // Account ↔ Roles (M:1)
            // ============================
            modelBuilder.Entity<Account>()
                .HasOne(a => a.Roles)
                .WithMany(r => r.Accounts)
                .HasForeignKey(a => a.Role_ID)
                .OnDelete(DeleteBehavior.Restrict);

            // ============================
            // Account ↔ Logins (1:M)
            // ============================
            modelBuilder.Entity<Login>()
                .HasOne(l => l.Account)
                .WithMany(a => a.Logins)
                .HasForeignKey(l => l.Account_ID)
                .OnDelete(DeleteBehavior.Restrict);

            // ============================
            // Login ↔ Status (M:1)
            // ============================
            modelBuilder.Entity<Login>()
                .HasOne(l => l.Status)
                .WithMany(s => s.Logins)
                .HasForeignKey(l => l.Status_ID)
                .OnDelete(DeleteBehavior.Restrict);

            // ============================
            // Account ↔ Exams (1:M)
            // ============================
            modelBuilder.Entity<Exam>()
                .HasOne(e => e.Teacher)
                .WithMany(a => a.Exams)
                .HasForeignKey(e => e.Account_ID)
                .OnDelete(DeleteBehavior.Restrict);

            // ============================
            // Exam ↔ Exam_QuestionBank (1:M)
            // ============================
            modelBuilder.Entity<Exam_QuestionBank>()
                .HasOne(eq => eq.Exam)
                .WithMany(e => e.Exam_QuestionBanks)
                .HasForeignKey(eq => eq.Exam_ID)
                .OnDelete(DeleteBehavior.Restrict);

            // ============================
            // QuestionType ↔ Question_Bank (1:M)
            // ============================
            modelBuilder.Entity<Question_Bank>()
                .HasOne(qb => qb.QuestionType)
                .WithMany(qt => qt.Question_Banks)
                .HasForeignKey(qb => qb.Question_Type_ID)
                .OnDelete(DeleteBehavior.Restrict);

            // ============================
            // Account (Teacher) ↔ Question_Bank (1:M)
            // ============================
            modelBuilder.Entity<Question_Bank>()
                .HasOne(qb => qb.Teacher)
                .WithMany(a => a.Question_Banks)
                .HasForeignKey(qb => qb.Account_ID)
                .OnDelete(DeleteBehavior.Restrict);

            // ============================
            // MCQ_Options ↔ Question_Bank (1:M)
            // ============================
            modelBuilder.Entity<Question_Bank>()
                .HasOne(qb => qb.MCQ)
                .WithMany(mcq => mcq.Question_Banks)
                .HasForeignKey(qb => qb.Option_ID)
                .OnDelete(DeleteBehavior.Restrict);

            // ============================
            // Question_Bank ↔ TrueOrFalse (1:1)
            // ============================
            modelBuilder.Entity<TrueOrFalse>()
                .HasOne(tf => tf.Question_Bank)
                .WithOne(qb => qb.TrueOrFalse)
                .HasForeignKey<TrueOrFalse>(tf => tf.Question_Bank_ID)
                .OnDelete(DeleteBehavior.Restrict);

            // ============================
            // Question_Bank ↔ Fill_In_Gaps (1:M)
            // ============================
            modelBuilder.Entity<Fill_In_Gaps>()
                .HasOne(fig => fig.Question_Bank)
                .WithMany(qb => qb.Fill_In_Gaps)
                .HasForeignKey(fig => fig.Question_Bank_ID)
                .OnDelete(DeleteBehavior.Restrict);

            // ============================
            // Question_Bank ↔ Exam_QuestionBank (1:M)
            // ============================
            modelBuilder.Entity<Exam_QuestionBank>()
                .HasOne(eq => eq.Question_Bank)
                .WithMany(qb => qb.Exam_QuestionBanks)
                .HasForeignKey(eq => eq.Question_Bank_ID)
                .OnDelete(DeleteBehavior.Restrict);

            // ============================
            // Account ↔ Exam_QuestionBank (Teacher) (1:M)
            // ============================
            modelBuilder.Entity<Exam_QuestionBank>()
                .HasOne(eq => eq.Teacher)
                .WithMany(a => a.Exam_QuestionBanks)
                .HasForeignKey(eq => eq.Account_ID)
                .OnDelete(DeleteBehavior.Restrict);

            // ============================
            // Exam_QuestionBank ↔ Student_ExamQB (1:M)
            // ============================
            modelBuilder.Entity<Student_ExamQB>()
                .HasOne(se => se.Exam_QuestionBank)
                .WithMany(eq => eq.student_ExamQBs)
                .HasForeignKey(se => se.Exam_QB_ID)
                .OnDelete(DeleteBehavior.Restrict);

            // ============================
            // Account ↔ Student_ExamQB (1:M)
            // ============================
            modelBuilder.Entity<Student_ExamQB>()
                .HasOne(se => se.Student)
                .WithMany(a => a.student_ExamQBs)
                .HasForeignKey(se => se.Account_ID)
                .OnDelete(DeleteBehavior.Restrict);
        }







    }
}
