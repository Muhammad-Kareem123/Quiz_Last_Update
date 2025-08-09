namespace Exam_Api_v2.DTOs
{
    public class StudentAnswerDTO
    {
        public int QuestionId { get; set; }
        public string Answer { get; set; } // For MCQ, T/F, Fill-in
    }
}
