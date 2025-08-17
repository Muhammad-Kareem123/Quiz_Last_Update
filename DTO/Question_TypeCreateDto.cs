using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Exam_Api_v2.DTO
{
    // DTO لإنشاء نوع سؤال جديد (Create)
    public class Question_TypeCreateDTO
    {
        [Required(ErrorMessage = "Question Type Name is Required")]
        public string QuestionType_Name { get; set; }

        public string? Question_Description { get; set; }

        [Required(ErrorMessage = "Mark is required")]
        public decimal Mark { get; set; }
    }

    // DTO لقراءة بيانات نوع السؤال (Read)
  
}

    
