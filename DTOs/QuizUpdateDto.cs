namespace Exam_Api_v2.DTOs
{
    public class QuizUpdateDto
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime? EndAt { get; set; }
        public string? Grade { get; set; }
        public bool Subimtted { get; set; } = false;
        public string Subject { get; set; }
    }
}
