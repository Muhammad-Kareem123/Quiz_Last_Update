using System;
using System.ComponentModel.DataAnnotations;

namespace Exam_Api_v2.DTO
{
    public class ExamCreateDto
    {
        [Required(ErrorMessage = "Title is Required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Category is Required")]
        public string Category { get; set; }

        public string? Exam_Description { get; set; }
        public DateTime? EndDate { get; set; }

        [Required(ErrorMessage = "Grade is required")]
        public int Grade { get; set; }

        [Required(ErrorMessage = "Teacher ID is required")]
        public int Account_ID { get; set; }
    }
}
