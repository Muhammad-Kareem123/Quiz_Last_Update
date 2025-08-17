namespace Exam_Api_v2.DTO
{
    public class StatusReadDTO
    {
        public int Status_ID { get; set; }
        public string Status_Name { get; set; }
        public string? Business_Entity { get; set; }
        public int? Order_Num { get; set; }
        public int AccountsCount { get; set; } // Count of related accounts
        public int LoginsCount { get; set; }   // Count of related logins
    }
}
