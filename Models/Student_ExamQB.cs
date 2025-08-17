using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Exam_Api_v2.Models
{
    public class Student_ExamQB
    {
        [Key]
        public int Student_QB { get; set; }
        [Required(ErrorMessage = "Student Answer is Required")]
        public string StudentAnswer { get; set; }
        [ForeignKey("Account_ID")]
        public int Account_ID { get; set; }
        public Account Student { get; set; }
        [ForeignKey("Exam_QB_ID")]
        public int Exam_QB_ID { get; set; }
        public Exam_QuestionBank Exam_QuestionBank { get; set; }

    }
}
