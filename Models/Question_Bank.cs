using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Exam_Api_v2.Models
{
    public class Question_Bank
    {
        [Key]
        public int Question_Bank_ID { get; set; }
        [Required(ErrorMessage = "Question Text is Required")]
        public string Question_Text { get; set; }
        [Required(ErrorMessage = "Mark is required")]
        public decimal Mark { get; set; }
        [Required(ErrorMessage = "Correct Answer is Required")]
        public string Correct_Answer { get; set; }
        [ForeignKey("Account_ID")]
        public int Account_ID { get; set; }
        public Account Teacher { get; set; }
        [ForeignKey("Question_Type_ID ")]
        public int Question_Type_ID { get; set; }
        public QuestionType QuestionType { get; set; }
        [ForeignKey("Option_ID")]
        public int Option_ID { get; set; }
        public MCQ_Options Options { get; set; }
        public MCQ_Options MCQ { get; set; }
        public TrueOrFalse TrueOrFalse { get; set; }
        public ICollection<Fill_In_Gaps> Fill_In_Gaps { get; set; }
        public ICollection<Exam_QuestionBank> Exam_QuestionBanks { get; set; }

    }
}
