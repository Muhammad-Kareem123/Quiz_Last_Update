using Microsoft.Data.SqlClient.DataClassification;

namespace Exam_Api_v2.Models
{
    // Models/Question.cs
    public abstract class Question
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int ExamId { get; set; }
        public Exam Exam { get; set; }

        public string Discriminator { get; set; } // "MCQ", "TrueFalse", "FillInTheGaps"
    }

    public class MCQQuestion : Question
    {

        public int Degree { get; set; }
        public string Selected { get; set; }
        public string OptionA { get; set; }
        public string OptionB { get; set; }
        public string OptionC { get; set; }
        public string OptionD { get; set; }
        public string CorrectOption { get; set; }
    }

    public class TrueFalseQuestion : Question
    {
        public string StudentAnswer { get; set; }
        public int Degree { get; set; }
        public bool CorrectAnswer { get; set; }
    }

    public class FillInTheGapsQuestion : Question
    {
        public int Degree { get; set; }
        public string StudentAnswer { get; set; }
        public string CorrectAnswer { get; set; }
    }

}
