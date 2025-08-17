using Exam_Api_v2.DTO;

using Exam_Api_v2.Models;
using System.Linq;

namespace Exam_Api_v2.Converters
{
    public static class ExamQuestionBankConverters
    {
        // Convert من Entity إلى ReadDTO
        public static Exam_QuestionBankReadDTO ToReadDTO(this Exam_QuestionBank examQuestionBank)
        {
            return new Exam_QuestionBankReadDTO
            {
                Exam_QB_ID = examQuestionBank.Exam_QB_ID,
                Mark = examQuestionBank.Mark,
                Exam_ID = examQuestionBank.Exam_ID,
                ExamTitle = examQuestionBank.Exam?.Title, // افترض وجود خاصية Title في Exam
                Question_Bank_ID = examQuestionBank.Question_Bank_ID,
                Question = examQuestionBank.Question_Bank?.Question_Text, // افترض وجود خاصية Question في Question_Bank
                Account_ID = examQuestionBank.Account_ID,
                TeacherName = examQuestionBank.Teacher?.FullNameEn // افترض وجود خاصية FullNameEn في Account
            };
        }

        // Convert من CreateDTO إلى Entity
        public static Exam_QuestionBank ToEntity(this Exam_QuestionBankCreateDTO dto)
        {
            return new Exam_QuestionBank
            {
                Mark = dto.Mark,
                Exam_ID = dto.Exam_ID,
                Question_Bank_ID = dto.Question_Bank_ID,
                Account_ID = dto.Account_ID
            };
        }

        // Update Entity من UpdateDTO
        public static void UpdateFromDTO(this Exam_QuestionBank examQuestionBank, Exam_QuestionBankUpdateDTO dto)
        {
            if (dto.Mark.HasValue)
                examQuestionBank.Mark = dto.Mark.Value;

            if (dto.Exam_ID.HasValue)
                examQuestionBank.Exam_ID = dto.Exam_ID.Value;

            if (dto.Question_Bank_ID.HasValue)
                examQuestionBank.Question_Bank_ID = dto.Question_Bank_ID.Value;
        }
    }
}
