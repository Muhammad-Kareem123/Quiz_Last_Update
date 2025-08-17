using Exam_Api_v2.Models;

namespace Exam_Api_v2.DTO
{
    public class MCQ_OptionsUpdateDto
    {
        public string? Option_Text { get; set; }

        public bool? Is_Correct { get; set; }
        public ICollection<Question_BankUpdateDTO> Question_Banks { get; set; }
    }
}
