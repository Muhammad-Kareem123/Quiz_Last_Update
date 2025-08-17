using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Exam_Api_v2.Models
{
    public class Exam
    {
        [Key]
        public int Exam_ID { get; set; }
        [Required(ErrorMessage = "Title is Required")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Category is Required")]
        public string Category { get; set; }
        public string? Exam_Description { get; set; }
        public DateTime? EndDate { get; set; }
        [Required(ErrorMessage = "Grade is required")]
        public int Grade { get; set; }
        [ForeignKey("Account_ID ")]
        public int Account_ID { get; set; }
        public Account Teacher { get; set; }

        public ICollection<Exam_QuestionBank> Exam_QuestionBanks { get; set; }
    }
}
