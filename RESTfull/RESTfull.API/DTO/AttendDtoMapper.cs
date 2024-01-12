using RESTfull.Domain.Model;
using System;

namespace RESTfull.API.DTO
{
    public class AttendDtoMapper
    {
        public static AttendDto ToDto(Attendance attend)
        {
            var attendDto = new AttendDto
            {
                Id_class = attend.Id_class,
                Id_student = attend.Id_student,
                Attend = attend.Attend
            };

            return attendDto;
        }

        public static ICollection<AttendDto> ToDtoList(ICollection<Attendance> attends)
        {
            var attendsDto = new List<AttendDto>();
            foreach (var attend in attends)
            {
                attendsDto.Add(ToDto(attend));
            }
            return attendsDto;
        }

        public static Attendance ToAttend(AttendDto  attendDto)
        {
            var attend = new Attendance
            {
                Id_class = attendDto.Id_class,
                Id_student = attendDto.Id_student,
                Attend = attendDto.Attend
            };

            return attend;
        }

        public static Attendance ToAttendWithId(AttendDtoWithId attendDto)
        {
            var attend = new Attendance
            {
                Id = attendDto.Id,
                Id_class = attendDto.Id_class,
                Id_student = attendDto.Id_student,
                Attend = attendDto.Attend
            };

            return attend;
        }
    }
}
