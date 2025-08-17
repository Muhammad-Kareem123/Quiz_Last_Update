namespace Exam_Api_v2.DTO
{
    public class TrueOrFalseReadDTO
    {
        public int Question_Bank_ID { get; set; }
        public bool Correct_Ans { get; set; }
        public string QuestionText { get; set; } // From related Question_Bank
    }
}
