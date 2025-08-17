using System.ComponentModel.DataAnnotations;

namespace Exam_Api_v2.DTO
{
    public class AccountUpdateDto
    {
       
        public string NationalId { get; set; }
       
        public string Password { get; set; }
        
        public string Email { get; set; }
       
        public string? Phone { get; set; }
      
        public string FullNameEn { get; set; }
      
        public string FullNameAr { get; set; }
     
        public string? ResetToken { get; set; }
        public DateTime? ResetTokenExpiry { get; set; }
        public DateTime Created_At { get; set; } = DateTime.Now;
        public bool IsActive { get; set; } = true;
        public int Role_ID { get; set; }
        [Required(ErrorMessage = "Status is required")]
        public int Status_ID { get; set; }

    }
}
