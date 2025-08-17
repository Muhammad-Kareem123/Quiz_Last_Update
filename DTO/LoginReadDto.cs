namespace Exam_Api_v2.DTO
{
    public class LoginReadDTO
    {
        public int Login_ID { get; set; }
        public string Email { get; set; }
        public int Status_ID { get; set; }
        public string StatusName { get; set; } // اسم الحالة
        public int Account_ID { get; set; }
        public string AccountFullName { get; set; } // اسم الحساب
    }
}
