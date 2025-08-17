using System.ComponentModel.DataAnnotations;

namespace Exam_Api_v2.DTO
{
    public class StatusUpdateDTO
    {
        [StringLength(100, ErrorMessage = "Status name cannot exceed 100 characters")]
        public string? Status_Name { get; set; }

        [StringLength(50, ErrorMessage = "Business entity cannot exceed 50 characters")]
        public string? Business_Entity { get; set; }

        public int? Order_Num { get; set; }
    }
}
