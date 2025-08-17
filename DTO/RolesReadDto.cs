namespace Exam_Api_v2.DTO
{
    public class RolesReadDTO
    {
        public int Role_ID { get; set; }
        public string Role_Name { get; set; }
        public int? Order_Num { get; set; }
        public string? Business_Entity { get; set; }
        public ICollection<AccountReadDto> accounts { get; set; } 
    }
}
