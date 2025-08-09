using Exam_Api_v2.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Exam_Api_v2.Data
{
    // Data/AppDbContext.cs
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Exam> Exams { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Question>()
                .HasDiscriminator<string>("Discriminator")
                .HasValue<MCQQuestion>("MCQ")
                .HasValue<TrueFalseQuestion>("TrueFalse")
                .HasValue<FillInTheGapsQuestion>("FillInTheGaps");
        }
    }

}
