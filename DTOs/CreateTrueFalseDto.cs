namespace Exam_Api_v2.DTOs
{
    public class CreateTrueFalse : CreateQuestionDto
    {
        public int Degree { get; set; }
        public bool CorrectAnswer { get; set; }
        public string StudentAnswer { get; set; }

        public CreateTrueFalse() => Type = "TrueFalse";
    }

}
