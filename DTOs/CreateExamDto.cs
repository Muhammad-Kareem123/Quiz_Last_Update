namespace Exam_Api_v2.DTOs
{
    // DTOs/ExamDto.cs
    public class CreateExamDto
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime? EndAt { get; set; }
        public string? Grade { get; set; }
        public bool Subimtted { get; set; } = false;
        public string Subject { get; set; }
        public List<CreateQuestionDto> Questions { get; set; }
    }

}
