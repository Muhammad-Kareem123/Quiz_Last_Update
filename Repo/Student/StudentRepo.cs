using Exam_Api_v2.Data;
using Exam_Api_v2.DTOs;
using Microsoft.EntityFrameworkCore;

namespace Exam_Api_v2.Repo.Student
{
    public class StudentRepo : IStudent
    {
        private readonly AppDbContext _context;
        public StudentRepo(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Models.Student> CreateStudent(CreateStudentDto dto)
        {
            var s = new Models.Student
            {
                FullName = dto.FullName,
                Email = dto.Email,
                Grade = dto.Grade,
                DateOfBirth = dto.DateOfBirth,
                Gender = dto.Gender,
                PhoneNumber = dto.PhoneNumber,

            };
            _context.Students.AddAsync(s);
            await _context.SaveChangesAsync();
            return s;
        }
        public async Task<bool> DeleteStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return false;
                throw new KeyNotFoundException($"Student with ID {id} not found.");
            }
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Models.Student>> GetAllStudents()
        {
            return await _context.Students.ToListAsync();
        }


        public async Task<Models.Student?> GetStudentById(int id)
        {
            return await _context.Students.FindAsync(id);
        }

        public async Task<Models.Student> UpdateStudent(int id, StudentUpdateDto dto)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
                throw new KeyNotFoundException($"Student with ID {id} not found.");

            if (!string.IsNullOrEmpty(dto.FullName))
                student.FullName = dto.FullName;

            if (!string.IsNullOrEmpty(dto.Email))
                student.Email = dto.Email;

            if (!string.IsNullOrEmpty(dto.PhoneNumber))
                student.PhoneNumber = dto.PhoneNumber;

            if (!string.IsNullOrEmpty(dto.Gender))
                student.Gender = dto.Gender;

            if (!string.IsNullOrEmpty(dto.Grade))
                student.Grade = dto.Grade;

            if (dto.DateOfBirth != default)
                student.DateOfBirth = dto.DateOfBirth;

            _context.Students.Update(student);
            await _context.SaveChangesAsync();

            return student;
        }

    }
}
