using Exam_Api_v2.Models;
using System.ComponentModel.DataAnnotations;

namespace Exam_Api_v2.DTO
{
    // DTO for creating new MCQ option
    public class MCQ_OptionCreateDTO
    {
        [Required(ErrorMessage = "Option Text is Required")]
       
        public string Option_Text { get; set; }


        public bool Is_Correct { get; set; } = false;
        public ICollection<Question_BankCreateDTO> Question_Banks { get; set; }
    }


    // DTO for updating MCQ option
   
    // Supporting DTO for related questions
    
}
