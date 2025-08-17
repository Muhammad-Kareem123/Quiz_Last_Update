using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Exam_Api_v2.Models
{
    public class Exam_QuestionBank
    {
        [Key]
        public int Exam_QB_ID { get; set; }
        [Required(ErrorMessage = "Mark is required")]
        public decimal Mark { get; set; }
        [ForeignKey("Exam")]
        public int Exam_ID { get; set; }
        public Exam Exam { get; set; }

        [ForeignKey("Question_Bank")]
        public int Question_Bank_ID { get; set; }
        public Question_Bank Question_Bank { get; set; }
        [ForeignKey("Account_ID")]
        public int Account_ID { get; set; }
        public Account Teacher { get; set; }
        public ICollection<Student_ExamQB> student_ExamQBs { get; set; }
    }
}
