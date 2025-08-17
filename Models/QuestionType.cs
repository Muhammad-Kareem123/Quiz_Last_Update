using System.ComponentModel.DataAnnotations;

namespace Exam_Api_v2.Models
{
    public class QuestionType
    {
        [Key]
        public int Question_Type_ID { get; set; }
        [Required(ErrorMessage = "Question Text is Required")]
        public string QuestionType_Name { get; set; }
        public string? Question_Description { get; set; }
        [Required(ErrorMessage = "Mark is required")]
        public decimal Mark { get; set; }
        public ICollection<Question_Bank> Question_Banks { get; set; }
    }
}
