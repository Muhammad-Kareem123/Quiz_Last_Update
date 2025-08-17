using System.ComponentModel.DataAnnotations;

namespace Exam_Api_v2.DTO
{
    // DTO لإنشاء سؤال ملء الفراغات جديد (Create)
    public class Fill_In_GapsCreateDTO
    {
        public string? Gap_Text { get; set; }

        [Required(ErrorMessage = "Correct Answer is required")]
        public string Correct_Answer { get; set; }

        [Required(ErrorMessage = "Question Bank ID is required")]
        public int Question_Bank_ID { get; set; }
    }

    // DTO لقراءة بيانات سؤال ملء الفراغات (Read)
  

    // DTO لتحديث سؤال ملء الفراغات (Update)
    
}
