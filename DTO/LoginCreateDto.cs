using System.ComponentModel.DataAnnotations;

namespace Exam_Api_v2.DTO
{
    // DTO لإنشاء تسجيل دخول جديد (Create)
    public class LoginCreateDTO
    {
        [Required(ErrorMessage = "Email is Required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Status ID is required")]
        public int Status_ID { get; set; }

        [Required(ErrorMessage = "Account ID is required")]
        public int Account_ID { get; set; }
    }

    // DTO لقراءة بيانات تسجيل الدخول (Read)
  

    // DTO لتحديث تسجيل الدخول (Update)
   
}
