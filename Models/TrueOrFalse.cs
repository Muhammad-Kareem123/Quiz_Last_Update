using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Exam_Api_v2.Models
{
    public class TrueOrFalse
    {
        [Key]
        [ForeignKey("Question_Bank")]
        public int Question_Bank_ID { get; set; }
        [Required(ErrorMessage = "Correct Answer is requied")]
        public bool Correct_Ans { get; set; }
        public Question_Bank Question_Bank { get; set; }

    }
}
