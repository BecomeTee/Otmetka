using RESTfull.Domain.Model;
using System;

namespace RESTfull.API.DTO
{
    public class StudentDtoMapper
    {
        public static StudentDto ToDto(Student student)
        {
            var studentDto = new StudentDto
            {
                Group = student.Group,
                Name = student.Name
            };

            return studentDto;
        }
    }
}
