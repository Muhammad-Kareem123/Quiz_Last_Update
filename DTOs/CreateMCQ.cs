namespace Exam_Api_v2.DTOs
{
    // DTOs/CreateMCQDto.cs
    public class CreateMCQ : CreateQuestionDto
    {
        public int Degree { get; set; }

        public string OptionA { get; set; }
        public string OptionB { get; set; }
        public string OptionC { get; set; }
        public string OptionD { get; set; }
        public string CorrectOption { get; set; }

        public CreateMCQ() => Type = "MCQ";
    }

}
