using Exam_Api_v2.DTO;

using Exam_Api_v2.Models;

namespace Exam_Api_v2.Converter
{
    public static class StudentExamQBConverters
    {
        // Convert from Entity to ReadDTO
        public static StudentExamQBReadDTO ToReadDTO(this Student_ExamQB studentExamQB)
        {
            return new StudentExamQBReadDTO
            {
                Student_QB = studentExamQB.Student_QB,
                StudentAnswer = studentExamQB.StudentAnswer,
                Account_ID = studentExamQB.Account_ID,
                StudentName = studentExamQB.Student?.FullNameEn, // Assuming FullNameEn exists in Account
                Exam_QB_ID = studentExamQB.Exam_QB_ID
            };
        }

        // Convert from CreateDTO to Entity
        public static Student_ExamQB ToEntity(this StudentExamQBCreateDTO dto)
        {
            return new Student_ExamQB
            {
                StudentAnswer = dto.StudentAnswer,
                Account_ID = dto.Account_ID,
                Exam_QB_ID = dto.Exam_QB_ID
            };
        }

        // Update Entity from UpdateDTO
        public static void UpdateFromDTO(this Student_ExamQB studentExamQB, StudentExamQBUpdateDTO dto)
        {
            if (!string.IsNullOrWhiteSpace(dto.StudentAnswer))
                studentExamQB.StudentAnswer = dto.StudentAnswer;
        }
    }
}
