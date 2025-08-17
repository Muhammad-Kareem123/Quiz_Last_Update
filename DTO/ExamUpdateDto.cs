namespace Exam_Api_v2.DTO
{
    public class ExamUpdateDto
    {
     
        public string Title { get; set; }
        
        public string Category { get; set; }
        public string? Exam_Description { get; set; }
        public DateTime? EndDate { get; set; }
        
        public int Grade { get; set; }
       
        public int Account_ID { get; set; }
    }
}
