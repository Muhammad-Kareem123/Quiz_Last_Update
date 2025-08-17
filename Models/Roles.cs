using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Exam_Api_v2.Models
{
    [Index(nameof(Role_Name), IsUnique = true)]
    public class Roles
    {
        [Key]
        public int Role_ID { get; set; }
        [Required(ErrorMessage = "Role Name is Required")]
        public string Role_Name { get; set; }
        public int? Order_Num { get; set; }
        public string? Business_Entity { get; set; }
        public ICollection<Account> Accounts { get; set; }
    }
}
