using System.ComponentModel.DataAnnotations;

namespace Exam_Api_v2.Models
{
    public class Status
    {
        [Key]
        public int Status_ID { get; set; }
        [Required(ErrorMessage ="Status Name is Required")]
        public string Status_Name { get; set; }
        public string? Business_Entity { get; set; }
        public int? Order_Num { get; set; }
        public ICollection<Account> Accounts { get; set; }
        public ICollection<Login> Logins { get; set; }
    }
}
