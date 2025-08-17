using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Exam_Api_v2.DTO
{
    // DTO لإنشاء دور جديد (Create)
    public class RolesCreateDTO
    {
        [Required(ErrorMessage = "Role Name is Required")]
        public string Role_Name { get; set; }

        public int? Order_Num { get; set; }
        public string? Business_Entity { get; set; }
        public ICollection<AccountReadDto> accounts { get; set; }
    }

    
    
}
