namespace Exam_Api_v2.Models
{
    public class Exam
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        
        public DateTime? EndAt { get; set; }
        public bool Subimtted { get; set; } = false;
        public string? Grade { get; set; }
        public String Subject { get; set; }

        public ICollection<Question> Questions { get; set; }
    }

}
