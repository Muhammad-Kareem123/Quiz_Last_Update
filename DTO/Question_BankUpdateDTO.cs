namespace Exam_Api_v2.DTO
{
    public class Question_BankUpdateDTO
    {
        public string? Question_Text { get; set; }
        public decimal? Mark { get; set; }
        public string? Correct_Answer { get; set; }
        public int? Account_ID { get; set; }
        public int? Question_Type_ID { get; set; }
        public int? Option_ID { get; set; }
        public ICollection<Fill_In_GapsUpdateDto> Fill_In_Gaps { get; set; }
    }
}
