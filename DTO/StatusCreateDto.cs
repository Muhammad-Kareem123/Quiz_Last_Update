using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Exam_Api_v2.DTO
{
    // DTO for creating new status
    public class StatusCreateDTO
    {
        [Required(ErrorMessage = "Status Name is Required")]
        
        public string Status_Name { get; set; }

       
        public string? Business_Entity { get; set; }

        public int? Order_Num { get; set; }
        public ICollection<LoginReadDTO>? logins { get; set; }
        public ICollection<AccountReadDto>? accounts { get; set; }
    }

    // DTO for reading status data


    // DTO for updating status
   
}
