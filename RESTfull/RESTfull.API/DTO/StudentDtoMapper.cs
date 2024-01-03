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
                Id = student.Id,
                Group = student.Group,
                Name = student.Name
            };

            return studentDto;
        }

        public static ICollection<StudentDto> ToDtoList(ICollection<Student> students)
        {
            var studentDto = new List<StudentDto>();
            foreach (var student in students)
            {
                studentDto.Add(ToDto(student));
            }
            return studentDto;
        }

        public static Student ToStudent(StudentDto studentDto)
        {
            var student = new Student
            {
                Group = studentDto.Group,
                Name = studentDto.Name
            };

            return student;
        }

        public static Student ToStudentWithId(StudentDto studentDto)
        {
            var student = new Student
            {
                Id = studentDto.Id,
                Group = studentDto.Group,
                Name = studentDto.Name
            };

            return student;
        }
    }
}
