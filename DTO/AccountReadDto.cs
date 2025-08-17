namespace Exam_Api_v2.DTO
{
    public class AccountReadDto
    {
        public int Account_ID { get; set; }
        public string NationalId { get; set; }
        public string Email { get; set; }
        public string? Phone { get; set; }
        public string FullNameEn { get; set; }
        public string FullNameAr { get; set; }
        public string? ResetToken { get; set; }
        public DateTime? ResetTokenExpiry { get; set; }
        public DateTime Created_At { get; set; } = DateTime.Now;
        public bool IsActive { get; set; } = true;
        
        public int Status_ID { get; set; }
        public string StatusName { get; set; }
        public int Role_ID { get; set; }
        public string RoleName { get; set; }
    }
}
