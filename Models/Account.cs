using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Exam_Api_v2.Models
{
    [Index(nameof(NationalId),IsUnique = true)]
    [Index(nameof(Email), IsUnique = true)]
    public class Account
    {
        [Key]
        public int Account_ID { get; set; }
        [Required(ErrorMessage = "National ID is Required")]
        public string NationalId { get; set; }
        [Required(ErrorMessage ="Password Hash is Required")]
        public string Password_Hash { get; set; }
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
        public string? Phone { get; set; }
        [Required(ErrorMessage = "Full Name in English is required")]
        public string FullNameEn { get; set; }
        [Required(ErrorMessage = "Full Name in Arabic is required")]
        public string FullNameAr { get; set; }
        public string? ResetToken { get; set; }
        public DateTime? ResetTokenExpiry { get; set; }
        public DateTime Created_At { get; set; } = DateTime.Now;
        public bool IsActive { get; set; } = true;
        [ForeignKey("Status_ID")]
        public int Status_ID { get; set; }
        public Status Status { get; set; }  
        [ForeignKey("Role_ID")]
        public int Role_ID { get; set; }
        public Roles Roles { get; set; }
        public ICollection<Login> Logins { get; set; }
        public ICollection<Question_Bank> Question_Banks { get; set; }
        public ICollection<Exam> Exams { get; set; }
        public ICollection<Exam_QuestionBank> Exam_QuestionBanks { get; set; }
        public ICollection<Student_ExamQB> student_ExamQBs { get; set; }

    }
}
