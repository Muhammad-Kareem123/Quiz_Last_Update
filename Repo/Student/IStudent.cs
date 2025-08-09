using Exam_Api_v2.DTOs;

namespace Exam_Api_v2.Repo.Student
{
    public interface IStudent
    {
        Task<Models.Student> CreateStudent(CreateStudentDto dto);
        Task<List<Models.Student>> GetAllStudents();
        Task<Models.Student?> GetStudentById(int id);
        Task<Models.Student> UpdateStudent(int id, StudentUpdateDto dto);
        Task<bool> DeleteStudent(int id);
    }
}
