using Exam_Api_v2.DTO;

using Exam_Api_v2.Models;
using System.Linq;

namespace Exam_Api_v2.Converters
{
    public static class RolesConverters
    {
        // Convert من Entity إلى ReadDTO
        public static RolesReadDTO ToReadDTO(this Roles role)
        {
            return new RolesReadDTO
            {
                Role_ID = role.Role_ID,
                Role_Name = role.Role_Name,
                Order_Num = role.Order_Num,
                Business_Entity = role.Business_Entity,
                accounts = role.Accounts?.Select(a => new AccountReadDto
                {
                    Account_ID = a.Account_ID,
                    FullNameEn = a.FullNameEn// افترض وجود خاصية Account_Name في Account
                }).ToList() // تحويل قائمة الحسابات إلى DTO
            };
        }

        // Convert من CreateDTO إلى Entity
        public static Roles ToEntity(this RolesCreateDTO dto)
        {
            return new Roles
            {
                Role_Name = dto.Role_Name,
                Order_Num = dto.Order_Num,
                Business_Entity = dto.Business_Entity
            };
        }

        // Update Entity من UpdateDTO
        public static void UpdateFromDTO(this Roles role, RolesUpdateDTO dto)
        {
            if (!string.IsNullOrWhiteSpace(dto.Role_Name))
                role.Role_Name = dto.Role_Name;

            if (dto.Order_Num.HasValue)
                role.Order_Num = dto.Order_Num.Value;

            if (!string.IsNullOrWhiteSpace(dto.Business_Entity))
                role.Business_Entity = dto.Business_Entity;
        }
    }
}
