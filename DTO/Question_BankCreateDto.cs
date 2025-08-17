using Exam_Api_v2.DTO;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Exam_Api_v2.DTO
{
    // DTO لإنشاء سؤال جديد (Create)
    public class Question_BankCreateDTO
    {
        [Required(ErrorMessage = "Question Text is Required")]
        public string Question_Text { get; set; }

        [Required(ErrorMessage = "Mark is required")]
        public decimal Mark { get; set; }

        [Required(ErrorMessage = "Correct Answer is Required")]
        public string Correct_Answer { get; set; }

        [Required(ErrorMessage = "Account ID is required")]
        public int Account_ID { get; set; }

        [Required(ErrorMessage = "Question Type ID is required")]
        public int Question_Type_ID { get; set; }

        public int? Option_ID { get; set; } // Optional for MCQ
        public ICollection<Fill_In_GapsCreateDTO> fill_In_GapsCreateDTOs { get; set; }
    }

    // DTO لقراءة بيانات السؤال (Read)
   

  
}
