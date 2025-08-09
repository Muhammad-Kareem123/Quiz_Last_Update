using Exam_Api_v2.DTOs;
using Exam_Api_v2.Models;

namespace Exam_Api_v2.Conventor
{
    public static class CustomerConventor
    {

        // Exam → ExamDto
        public static ExamResponseDto ToExamResponseDto(Exam exam)
        {
            if (exam == null)
                return null;

            exam.Questions ??= new List<Question>();

            return new ExamResponseDto
            {
                Id = exam.Id,
                Title = exam.Title,
                Description = exam.Description,
                Grade = exam.Grade,
                Subimtted = exam.Subimtted,
                Questions = exam.Questions.Select(q =>
                {
                    if (q is MCQQuestion mcq)
                    {
                        return new QuestionResponseDto
                        {
                            Id = mcq.Id,
                            Type = "MCQ",
                            Text = mcq.Text,
                            OptionA = mcq.OptionA,
                            OptionB = mcq.OptionB,
                            OptionC = mcq.OptionC,
                            OptionD = mcq.OptionD,
                            CorrectOption = mcq.CorrectOption
                        };
                    }
                    else if (q is TrueFalseQuestion tf)
                    {
                        return new QuestionResponseDto
                        {
                            Id = tf.Id,
                            Type = "TrueFalse",
                            Text = tf.Text,
                            CorrectAnswer = tf.CorrectAnswer.ToString()
                        };
                    }
                    else if (q is FillInTheGapsQuestion fitg)
                    {
                        return new QuestionResponseDto
                        {
                            Id = fitg.Id,
                            Type = "FillInTheGaps",
                            Text = fitg.Text,
                            CorrectAnswer = fitg.CorrectAnswer
                        };
                    }
                    return null;
                })
                .Where(x => x != null)
                .ToList()
            };
        }




        // CreateExamDto → Exam (Entity)
        public static Exam ToExamEntity(this CreateExamDto dto)
        {
            return new Exam
            {
                Title = dto.Title,
                Description = dto.Description,
                EndAt = dto.EndAt,
                Grade = dto.Grade,
                Subimtted = dto.Subimtted,
            };
        }

        // UpdateExamDto → تحديث الـ Exam (Entity موجود)
        public static void UpdateExamEntity(this Exam exam, QuizUpdateDto dto)
        {
            exam.Title = dto.Title;
            exam.Description = dto.Description;
            exam.EndAt = dto.EndAt;
            exam.Grade = dto.Grade;
            exam.Subimtted = dto.Subimtted;
        }
    }
}
