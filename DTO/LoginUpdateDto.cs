namespace Exam_Api_v2.DTO
{
    public class LoginUpdateDTO
    {
        public string? Email { get; set; }
        public string? Password_Hash { get; set; }
        public int? Status_ID { get; set; }
        public int? Account_ID { get; set; }
    }
}
