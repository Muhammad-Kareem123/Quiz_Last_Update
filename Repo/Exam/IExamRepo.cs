using Exam_Api_v2.DTOs;
using Exam_Api_v2.Models;

namespace Exam_Api_v2.Repo.Exam
{
    public interface IExamRepository
    {
        Task<Models.Exam> CreateExamAsync(CreateExamDto dto);
        Task<List<ExamResponseDto>> GetAllExamsAsync(); // Return DTO instead of entity
        Task DeleteExam(int id);
        Task<double> CalculateScoreAsync(List<StudentAnswerDTO> studentAnswers);
        Task<ExamResponseDto?> UpdateAsync(int id, QuizUpdateDto dto);
        Task<bool> DeleteAsync(int id);
         Task<List<ExamResponseDto>> GetByIdAsync(int id);
        Task<SubmitExamResultDto> SubmitExamAsync(int examId, List<StudentAnswerDTO> studentAnswers);

    }
}
