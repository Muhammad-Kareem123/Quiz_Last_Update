using Exam_Api_v2.DTO;

using Exam_Api_v2.Models;
using Microsoft.CodeAnalysis.Scripting;

using Exam_Api_v2.Models;


namespace Exam_Api_v2.Converters
{
    public static class LoginConverters
    {
        // Convert من Entity إلى ReadDTO
        public static LoginReadDTO ToReadDTO(this Login login)
        {
            return new LoginReadDTO
            {
                Login_ID = login.Login_ID,
                Email = login.Email,
                Status_ID = login.Status_ID,
                StatusName = login.Status?.Status_Name, // افترض وجود خاصية Name في Status
                Account_ID = login.Account_ID,
                AccountFullName = login.Account?.FullNameEn // افترض وجود خاصية FullNameEn في Account
            };
        }

        // Convert من CreateDTO إلى Entity
        public static Login ToEntity(this LoginCreateDTO dto)
        {
            return new Login
            {
                Email = dto.Email,
                Password_Hash = dto.Password, // تشفير كلمة المرور
                Status_ID = dto.Status_ID,
                Account_ID = dto.Account_ID
            };
        }

        // Update Entity من UpdateDTO
        public static void UpdateFromDTO(this Login login, LoginUpdateDTO dto)
        {
            if (!string.IsNullOrWhiteSpace(dto.Email))
                login.Email = dto.Email;

            if (!string.IsNullOrWhiteSpace(dto.Password_Hash))
                login.Password_Hash = dto.Password_Hash;

            if (dto.Status_ID.HasValue)
                login.Status_ID = dto.Status_ID.Value;

            if (dto.Account_ID.HasValue)
                login.Account_ID = dto.Account_ID.Value;
        }
    }
}
