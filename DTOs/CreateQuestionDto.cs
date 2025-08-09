using Exam_Api_v2.Conventor;
using System.Text.Json.Serialization;

namespace Exam_Api_v2.DTOs
{
    // DTOs/QuestionDtos.cs
    [JsonConverter(typeof(CreateQuestionDtoConverter))] // Attach converter here

    public abstract class CreateQuestionDto
    {
        public string Text { get; set; }
        public string Type { get; set; } // "MCQ", "TrueFalse", "FillInTheGaps"
    }

    public class CreateMCQDto : CreateQuestionDto
    {
        public int Degree { get; set; }
        public string Selected { get; set; }
        public string OptionA { get; set; }
        public string OptionB { get; set; }
        public string OptionC { get; set; }
        public string OptionD { get; set; }
        public string CorrectOption { get; set; }
    }

    public class CreateTrueFalseDto : CreateQuestionDto
    {
        public string StudentAnswer { get; set; }
        public int Degree { get; set; }
        public bool CorrectAnswer { get; set; }
    }

    public class CreateFillInTheGapsDto : CreateQuestionDto
    {
        public string StudentAnswer { get; set; }
        public int Degree { get; set; }
        public string CorrectAnswer { get; set; }
    }

}
