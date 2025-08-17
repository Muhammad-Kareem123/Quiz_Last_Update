using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Exam_Api_v2.DTO
{
    // DTO لإنشاء سؤال امتحان جديد (Create)
    public class Exam_QuestionBankCreateDTO
    {
        [Required(ErrorMessage = "Mark is required")]
        public decimal Mark { get; set; }

        [Required(ErrorMessage = "Exam ID is required")]
        public int Exam_ID { get; set; }

        [Required(ErrorMessage = "Question Bank ID is required")]
        public int Question_Bank_ID { get; set; }

        [Required(ErrorMessage = "Teacher ID is required")]
        public int Account_ID { get; set; }
    }

   

    
}
