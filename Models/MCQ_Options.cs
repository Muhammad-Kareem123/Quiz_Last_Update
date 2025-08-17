using System.ComponentModel.DataAnnotations;

namespace Exam_Api_v2.Models
{
    public class MCQ_Options
    {
        [Key]
        public int Option_ID { get; set; }
        [Required(ErrorMessage = "Option Text is Required")]
        public string Option_Text { get; set; }
        public bool Is_Correct { get; set; } = false;
        public ICollection<Question_Bank> Question_Banks { get; set; }
    }
}
