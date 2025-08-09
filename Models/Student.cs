using System.ComponentModel.DataAnnotations;

namespace Exam_Api_v2.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }

        [Required]
        public string FullName { get; set; }

        public string Email { get; set; }

        public string Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Grade { get; set; }


    }
}
