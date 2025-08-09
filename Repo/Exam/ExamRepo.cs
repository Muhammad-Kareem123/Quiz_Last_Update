using Exam_Api_v2.Conventor;
using Exam_Api_v2.Data;
using Exam_Api_v2.DTOs;
using Exam_Api_v2.Models;
using Microsoft.EntityFrameworkCore;

namespace Exam_Api_v2.Repo.Exam
{
    public class ExamRepository : IExamRepository
    {
        private readonly AppDbContext _context;

        public ExamRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Models.Exam> CreateExamAsync(CreateExamDto dto)
        {
            var exam = new Models.Exam { Title = dto.Title,Description = dto.Description ,EndAt = dto.EndAt,Subimtted=dto.Subimtted,Subject = dto.Subject,Grade = dto.Grade, Questions = new List<Question>() };

            foreach (var questionDto in dto.Questions)
            {
                Question q = questionDto.Type switch
                {
                    "MCQ" => new MCQQuestion
                    {
                        Text = questionDto.Text,
                        OptionA = ((CreateMCQDto)questionDto).OptionA,
                        OptionB = ((CreateMCQDto)questionDto).OptionB,
                        OptionC = ((CreateMCQDto)questionDto).OptionC,
                        OptionD = ((CreateMCQDto)questionDto).OptionD,
                        CorrectOption = ((CreateMCQDto)questionDto).CorrectOption
                    },
                    "TrueFalse" => new TrueFalseQuestion
                    {
                        Text = questionDto.Text,
                        CorrectAnswer = ((CreateTrueFalseDto)questionDto).CorrectAnswer,
                        Degree = ((CreateTrueFalseDto)questionDto).Degree,
                        StudentAnswer = ((CreateTrueFalseDto)questionDto).StudentAnswer
                    },
                    "FillInTheGaps" => new FillInTheGapsQuestion
                    {
                        Text = questionDto.Text,
                        CorrectAnswer = ((CreateFillInTheGapsDto)questionDto).CorrectAnswer
                    },
                    _ => throw new Exception("Invalid question type")
                };

                exam.Questions.Add(q);
            }
            exam.Subimtted = false;
            _context.Exams.Add(exam);
            await _context.SaveChangesAsync();
            return exam;
        }

        public async Task DeleteExam(int id)
        {
            var examToDelete = await _context.Exams.FindAsync(id);

            if (examToDelete == null)
            {
                // You can throw an exception, return a specific status, or log a message
                // depending on how you want to handle cases where the exam isn't found.
                throw new KeyNotFoundException($"Exam with ID {id} not found.");
            }

            _context.Exams.Remove(examToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ExamResponseDto>> GetAllExamsAsync()
        {
            var exams = await _context.Exams
                .Include(x => x.Questions).Where(u => u.Subimtted == false)
                .ToListAsync();

            return exams.Select(e => new ExamResponseDto
            {
                Id = e.Id,
                Title = e.Title!,
                Questions = e.Questions.Select(q =>
                {
                    return q switch
                    {
                        MCQQuestion mcq => new QuestionResponseDto
                        {
                            Id = mcq.Id,
                            Type = "MCQ",
                            Text = mcq.Text,
                            OptionA = mcq.OptionA,
                            OptionB = mcq.OptionB,
                            OptionC = mcq.OptionC,
                            OptionD = mcq.OptionD,
                            CorrectOption = mcq.CorrectOption
                        },
                        TrueFalseQuestion tf => new QuestionResponseDto
                        {
                            Id = tf.Id,
                            Type = "TrueFalse",
                            Text = tf.Text,
                            CorrectAnswer = tf.CorrectAnswer.ToString()
                        },
                        FillInTheGapsQuestion fill => new QuestionResponseDto
                        {
                            Id = fill.Id,
                            Type = "FillInTheGaps",
                            Text = fill.Text,
                            CorrectAnswer = fill.CorrectAnswer
                        },
                        _ => null
                    };
                }).Where(q => q != null).ToList()
            }).ToList();
        }

        public async Task<double> CalculateScoreAsync(List<StudentAnswerDTO> studentAnswers)
        {
            double totalScore = 0;

            foreach (var studentAnswer in studentAnswers)
            {
                var baseQuestion = await _context.Questions.FindAsync(studentAnswer.QuestionId);

                if (baseQuestion == null)
                    continue;

                Question question = null;

                switch (baseQuestion.Discriminator)
                {
                    case "MCQ":
                        question = await _context.Set<MCQQuestion>().FindAsync(studentAnswer.QuestionId);
                        if (question is MCQQuestion mcq)
                        {
                            var correct = mcq.CorrectOption?.Trim().ToLower();
                            var submitted = studentAnswer.Answer?.Trim().ToLower();
                            var Selected = mcq.Selected.Trim().ToLower();
                            submitted = Selected;
                            if (correct == submitted)
                                totalScore += mcq.Degree;
                        }
                        break;

                    case "TrueFalse":
                        question = await _context.Set<TrueFalseQuestion>().FindAsync(studentAnswer.QuestionId);
                        if (question is TrueFalseQuestion tf)
                        {
                            // Assuming student's answer comes as "true" or "false" string
                            if (bool.TryParse(studentAnswer.Answer, out bool studentBool))
                            {
                                if (studentBool == tf.CorrectAnswer)
                                    totalScore += tf.Degree;
                            }
                        }
                        break;

                    case "FillInTheGaps":
                        question = await _context.Set<FillInTheGapsQuestion>().FindAsync(studentAnswer.QuestionId);
                        if (question is FillInTheGapsQuestion fill)
                        {
                            var correct = fill.CorrectAnswer?.Trim().ToLower();
                            var submitted = studentAnswer.Answer?.Trim().ToLower();
                            if (correct == submitted)
                                totalScore += fill.Degree;
                        }
                        break;
                }
            }

            return totalScore;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var quiz = await _context.Exams.FindAsync(id);
            if (quiz == null) return false;

            _context.Exams.Remove(quiz);
            await _context.SaveChangesAsync();
            return true;
        }


        public async Task<ExamResponseDto?> UpdateAsync(int id, QuizUpdateDto dto)
        {
            var quiz = await _context.Exams.FirstOrDefaultAsync(e => e.Id == id);
            if (quiz == null) return null;

            if (!string.IsNullOrEmpty(dto.Title))
                quiz.Title = dto.Title;

            if (!string.IsNullOrEmpty(dto.Description))
                quiz.Description = dto.Description;

            if (dto.EndAt.HasValue)
                quiz.EndAt = dto.EndAt.Value;
            if (!string.IsNullOrEmpty(dto.Grade))
            {
                quiz.Grade = dto.Grade;
            }
            quiz.Subject = dto.Subject;

            await _context.SaveChangesAsync();
            return CustomerConventor.ToExamResponseDto(quiz);
        }
        public async Task<List<ExamResponseDto>> GetByIdAsync(int id)
        {
            var exams = await _context.Exams
                .Include(x => x.Questions)
                .Where(u=>u.Id == id).ToListAsync();

            return exams.Select(e => new ExamResponseDto
            {
                Id = e.Id,
                Title = e.Title!,
                Questions = e.Questions.Select(q =>
                {
                    return q switch
                    {
                        MCQQuestion mcq => new QuestionResponseDto
                        {
                            Id = mcq.Id,
                            Type = "MCQ",
                            Text = mcq.Text,
                            OptionA = mcq.OptionA,
                            OptionB = mcq.OptionB,
                            OptionC = mcq.OptionC,
                            OptionD = mcq.OptionD,
                            CorrectOption = mcq.CorrectOption
                        },
                        TrueFalseQuestion tf => new QuestionResponseDto
                        {
                            Id = tf.Id,
                            Type = "TrueFalse",
                            Text = tf.Text,
                            CorrectAnswer = tf.CorrectAnswer.ToString()
                        },
                        FillInTheGapsQuestion fill => new QuestionResponseDto
                        {
                            Id = fill.Id,
                            Type = "FillInTheGaps",
                            Text = fill.Text,
                            CorrectAnswer = fill.CorrectAnswer
                        },
                        _ => null
                    };
                }).Where(q => q != null).ToList()
            }).ToList();
        }

        public async Task<SubmitExamResultDto> SubmitExamAsync(int examId, List<StudentAnswerDTO> studentAnswers)
        {
            var exam = await _context.Exams.FindAsync(examId);

            if (exam == null)
                throw new KeyNotFoundException($"Exam with ID {examId} not found.");

            if (exam.Subimtted)
                throw new InvalidOperationException("Exam is already submitted.");

            // حساب الدرجة
            double score = await CalculateScoreAsync(studentAnswers);

            // تغيير حالة الامتحان
            exam.Subimtted = true;
            await _context.SaveChangesAsync();

            return new SubmitExamResultDto
            {
                Score = score,
                Message = "Exam submitted successfully."
            };
        }
    }
}
