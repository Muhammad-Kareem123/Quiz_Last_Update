using System.ComponentModel.DataAnnotations;

namespace Exam_Api_v2.DTO
{
    public class TrueOrFalseUpdateDTO
    {
        [Required(ErrorMessage = "Correct Answer is required")]
        public bool Correct_Ans { get; set; }
    }
}
