using Exam_Api_v2.DTO;
using Exam_Api_v2.Models;

namespace Exam_Api_v2.Converter
{
    public static class ExamConverter
    {
        // Convert from Entity to DTO
        public static ExamReadDto ToReadDTO(this Exam exam)
        {
            if (exam == null) return null;

            return new ExamReadDto
            {
                Exam_ID = exam.Exam_ID,
                Title = exam.Title,
                Category = exam.Category,
                Exam_Description = exam.Exam_Description,
                EndDate = exam.EndDate,
                Grade = exam.Grade,
                Account_ID = exam.Account_ID
            };
        }

        // Convert from DTO to Entity
        public static Exam ToEntity(this ExamCreateDto dto)
        {
            if (dto == null) return null;

            return new Exam
            {
                Title = dto.Title,
                Category = dto.Category,
                Exam_Description = dto.Exam_Description,
                EndDate = dto.EndDate,
                Grade = dto.Grade,
                Account_ID = dto.Account_ID
            };
        }

        // Update Entity from Update DTO
        public static void UpdateFromDTO(this Exam exam, ExamUpdateDto dto)
        {
            if (dto == null) return;

            exam.Title = dto.Title ?? exam.Title; // Keep existing value if null
            exam.Category = dto.Category ?? exam.Category;
            exam.Exam_Description = dto.Exam_Description ?? exam.Exam_Description;
            exam.EndDate = dto.EndDate ?? exam.EndDate;
            exam.Grade = dto.Grade != 0 ? dto.Grade : exam.Grade; // Keep existing value if 0 (assuming 0 is not a valid grade)
        }
    }
}
