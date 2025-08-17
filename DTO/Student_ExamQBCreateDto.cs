using System.ComponentModel.DataAnnotations;

namespace Exam_Api_v2.DTO
{
    // DTO for creating a new student exam question bank entry
    public class StudentExamQBCreateDTO
    {
        [Required(ErrorMessage = "Student Answer is Required")]
        public string StudentAnswer { get; set; }

        [Required(ErrorMessage = "Account ID is required")]
        public int Account_ID { get; set; }

        [Required(ErrorMessage = "Exam Question Bank ID is required")]
        public int Exam_QB_ID { get; set; }
    }

    // DTO for reading student exam question bank data
  

   
}
