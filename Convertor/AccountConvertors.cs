using Exam_Api_v2.DTO;

using Exam_Api_v2.Models;
using Microsoft.CodeAnalysis.Scripting;

namespace Exam_Api_v2.Converters
{
    public static class AccountConverters
    {
        // Convert من Entity إلى ReadDTO
        public static AccountReadDto ToReadDTO(this Account account)
        {
            return new AccountReadDto
            {
                Account_ID = account.Account_ID,
                NationalId = account.NationalId,
                Email = account.Email,
                Phone = account.Phone,
                FullNameEn = account.FullNameEn,
                FullNameAr = account.FullNameAr,
                Created_At = account.Created_At,
                IsActive = account.IsActive,
                Status_ID = account.Status_ID,
                StatusName = account.Status?.Status_Name, // افترض وجود خاصية Name في Status
                Role_ID = account.Role_ID,
                RoleName = account.Roles?.Role_Name // افترض وجود خاصية Name في Roles
            };
        }

        // Convert من CreateDTO إلى Entity
        public static Account ToEntity(this AccountCreateDTO dto)
        {
            return new Account
            {
                NationalId = dto.NationalId,
                Password_Hash = dto.Password, // تشفير كلمة المرور
                Email = dto.Email,
                Phone = dto.Phone,
                FullNameEn = dto.FullNameEn,
                FullNameAr = dto.FullNameAr,
                Role_ID = dto.Role_ID,
                Status_ID = dto.Status_ID,
                Created_At = DateTime.Now,
                IsActive = true
            };
        }

        // Update Entity من UpdateDTO
        public static void UpdateFromDTO(this Account account, AccountUpdateDto dto)
        {
            if (!string.IsNullOrWhiteSpace(dto.Phone))
                account.Phone = dto.Phone;

            if (!string.IsNullOrWhiteSpace(dto.Email))
                account.Email = dto.Email;

            if (!string.IsNullOrWhiteSpace(dto.FullNameEn))
                account.FullNameEn = dto.FullNameEn;

            if (!string.IsNullOrWhiteSpace(dto.FullNameAr))
                account.FullNameAr = dto.FullNameAr;

            if (dto.Status_ID != null)
                account.Status_ID = dto.Status_ID;

            if (dto.Role_ID!=null)
                account.Role_ID = dto.Role_ID;
        }
    }
}
