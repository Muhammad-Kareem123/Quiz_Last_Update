namespace Exam_Api_v2.DTOs
{
    // DTOs/QuestionResponseDto.cs
    public class QuestionResponseDto
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Text { get; set; }

        // For MCQ
        public string? OptionA { get; set; }
        public string? OptionB { get; set; }
        public string? OptionC { get; set; }
        public string? OptionD { get; set; }
        public string? CorrectOption { get; set; }

        // For TrueFalse & FillInTheGaps
        public string? CorrectAnswer { get; set; }
    }

}
