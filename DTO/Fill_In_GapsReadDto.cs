namespace Exam_Api_v2.DTO
{
    public class Fill_In_GapsReadDto
    {
        public int Gap_ID { get; set; }
        public string? Gap_Text { get; set; }
        public string Correct_Answer { get; set; }
        public int Question_Bank_ID { get; set; }
        public string Question { get; set; } // نص السؤال
    }
}
