using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Exam_Api_v2.Models
{
    public class Login
    {
        [Key]
        public int Login_ID { get; set; }
        [Required(ErrorMessage = "Email is Required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password Hash is Required")]
        public string Password_Hash { get; set; }
        [ForeignKey("Status_ID")]
        public int Status_ID { get; set; }
        public Status Status { get; set; }
        [ForeignKey("Account_ID")]
        public int Account_ID { get; set; }
        public Account Account { get; set; }

    }
}
