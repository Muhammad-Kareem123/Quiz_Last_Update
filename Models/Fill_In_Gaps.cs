using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Exam_Api_v2.Models
{
    public class Fill_In_Gaps
    {
        [Key]
        public int Gap_ID { get; set; }
        public string? Gap_Text { get; set; }
        [Required(ErrorMessage = "Correct Answer is requied")]
        public string Correct_Answer { get; set; }
        [ForeignKey("Question_Bank_ID")]
        public int Question_Bank_ID { get; set; }
        public Question_Bank Question_Bank { get; set; }


    }
}
