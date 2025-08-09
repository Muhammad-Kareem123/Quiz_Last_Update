namespace Exam_Api_v2.DTOs
{
    // DTOs/ExamResponseDto.cs
    public class ExamResponseDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime? EndAt { get; set; }
        public string? Grade { get; set; }
        public bool Subimtted { get; set; } = false;
        public string Subject { get; set; }
        public List<QuestionResponseDto> Questions { get; set; }
    }

}
