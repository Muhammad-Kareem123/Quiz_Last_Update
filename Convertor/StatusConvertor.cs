using Exam_Api_v2.DTO;

using Exam_Api_v2.Models;
using System.Linq;

namespace Exam_Api_v2.Converter
{
    public static class StatusConverter
    {
        public static StatusReadDTO ToReadDTO(this Status status)
        {
            return new StatusReadDTO
            {
                Status_ID = status.Status_ID,
                Status_Name = status.Status_Name,
                Business_Entity = status.Business_Entity,
                Order_Num = status.Order_Num,
                AccountsCount = status.Accounts?.Count ?? 0,
                LoginsCount = status.Logins?.Count ?? 0
            };
        }

        public static Status ToEntity(this StatusCreateDTO dto)
        {
            return new Status
            {
                Status_Name = dto.Status_Name,
                Business_Entity = dto.Business_Entity,
                Order_Num = dto.Order_Num
            };
        }

        public static void UpdateFromDTO(this Status status, StatusUpdateDTO dto)
        {
            if (!string.IsNullOrWhiteSpace(dto.Status_Name))
                status.Status_Name = dto.Status_Name;

            if (!string.IsNullOrWhiteSpace(dto.Business_Entity))
                status.Business_Entity = dto.Business_Entity;

            if (dto.Order_Num.HasValue)
                status.Order_Num = dto.Order_Num.Value;
        }
    }
}
