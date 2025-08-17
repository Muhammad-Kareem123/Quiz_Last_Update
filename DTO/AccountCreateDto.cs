using System.ComponentModel.DataAnnotations;

namespace Exam_Api_v2.DTO
{
    public class AccountCreateDTO
    {
        [Required(ErrorMessage = "National ID is Required")]
        public string NationalId { get; set; }
        [Required(ErrorMessage = "Password is Required")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        [Phone(ErrorMessage = "Invalid Phone Number")]
        public string? Phone { get; set; }
        [Required(ErrorMessage = "Full Name in English is required")]
        public string FullNameEn { get; set; }
        [Required(ErrorMessage = "Full Name in Arabic is required")]
        public string FullNameAr { get; set; }
        [Required(ErrorMessage = "Role is required")]
        public string? ResetToken { get; set; }
        public DateTime? ResetTokenExpiry { get; set; }
        public DateTime Created_At { get; set; } = DateTime.Now;
        public bool IsActive { get; set; } = true;
        public int Role_ID { get; set; }
        [Required(ErrorMessage = "Status is required")]
        public int Status_ID { get; set; }

    }
}
