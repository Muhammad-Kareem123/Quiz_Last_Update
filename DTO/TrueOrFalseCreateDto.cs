using System.ComponentModel.DataAnnotations;

namespace Exam_Api_v2.DTO
{
    // DTO for creating new TrueOrFalse question
    public class TrueOrFalseCreateDTO
    {
        [Required(ErrorMessage = "Question Bank ID is required")]
        public int Question_Bank_ID { get; set; }

        [Required(ErrorMessage = "Correct Answer is required")]
        public bool Correct_Ans { get; set; }
    }

    // DTO for reading TrueOrFalse question data
  

    // DTO for updating TrueOrFalse question
   
}
