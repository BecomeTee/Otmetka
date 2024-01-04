using RESTfull.Domain.Model;
using System;

namespace RESTfull.API.DTO
{
    public class ClassDtoMapper
    {
        public static ClassDto ToDto(Class _class)
        {
            var classDto = new ClassDto
            {
                Id = _class.Id,
                Name = _class.Name,
                DateStart = _class.DateStart,
                DateFinish = _class.DateFinish,
                Room = _class.Room,
                Teacher = _class.Teacher
            };

            return classDto;
        }

        public static ICollection<ClassDto> ToDtoList(ICollection<Class> classes)
        {
            var classesDto = new List<ClassDto>();
            foreach (var _class in classes)
            {
                classesDto.Add(ToDto(_class));
            }
            return classesDto;
        }

        public static Class ToStudent(ClassDto  classDto)
        {
            var _class = new Class
            {
                Name = classDto.Name,
                DateStart = classDto.DateStart,
                DateFinish = classDto.DateFinish,
                Room = classDto.Room,
                Teacher = classDto.Teacher
            };

            return _class;
        }

        /*public static Student ToStudentWithId(StudentDto studentDto)
        {
            var student = new Student
            {
                Id = studentDto.Id,
                Group = studentDto.Group,
                Name = studentDto.Name
            };

            return student;
        }*/
    }
}
