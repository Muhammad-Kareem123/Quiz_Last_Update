namespace Exam_Api_v2.DTOs
{
    // DTOs/CreateFillInTheGapsDto.cs
    public class CreateFillInTheGaps : CreateQuestionDto
    {
        public string CorrectAnswer { get; set; }

        public int Degree { get; set; }
        public CreateFillInTheGaps() => Type = "FillInTheGaps";
    }

}
