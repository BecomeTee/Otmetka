using Microsoft.AspNetCore.Mvc;
using RESTfull.Infrastructure.Interfaces;
using RESTfull.Domain.Model;
using RESTfull.Infrastructure.Data;
using RESTfull.API.DTO;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RESTfull.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudController : ControllerBase
    {

        private readonly InterfaceStudent _studentRepository;

        public StudController(InterfaceStudent studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [HttpGet]
        public ICollection<Student> GetStudents()
        {
            var students = _studentRepository.GetStudents();
            return students;
        }


        [HttpGet("{id:Guid}")]
        public StudentDto GetStudent(Guid id)
        {
            var student = _studentRepository.GetStudent(id);
            var studentDto = StudentDtoMapper.ToDto(student);
            return studentDto;
        }

        /*[HttpGet("{id:Guid}")]
        public IActionResult GetStudent(Guid id)
        {
            var student = _studentRepository.GetStudent(id);

            if (student == null)
            {
                // Если студент не найден, возвращаем статус 404 (Not Found)
                return NotFound();
            }

            var studentDto = StudentDtoMapper.ToDto(student);
            return Ok(studentDto);
        }*/

        [HttpGet("getStudentByName/{name}")]
        public StudentDto GetStudentByName(string name)
        {
            var student = _studentRepository.GetStudentByName(name);
            var studentDto = StudentDtoMapper.ToDto(student);
            return studentDto;
        }

        [HttpGet("GetStudentsByNameNGroup/{name}/{group}")]
        public ICollection<StudentDto> GetStudentsByNameNGroup(string name, string group)
        {
            var students = _studentRepository.GetStudentsByNameNGroup(name,group);
            var studentsDto = StudentDtoMapper.ToDtoList(students);
            return studentsDto;
        }



        /*[HttpPost]
        public IActionResult CreateStudent([FromBody] Student createStudent)
        {
            if (createStudent == null)
            {
                return BadRequest(ModelState);
            }

            var student = _studentRepository.GetStudents()
                .Where(c => c.Name.Trim().ToUpper() == createStudent.Name.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (student != null)
            {
                ModelState.AddModelError("", "Student already exist");
                return StatusCode(442, ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(!_studentRepository.CreateStudent(createStudent))
            {
                ModelState.AddModelError("", "Somesing went wrong");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfull created");
        }*/
        [HttpPost]
        public IActionResult CreateStudent([FromBody] StudentDto createStudent)
        {
            if (createStudent == null)
            {
                return BadRequest(ModelState);
            }

            /*var student = _studentRepository.GetStudents()
                .Where(c => c.Name.Trim().ToUpper() == createStudent.Name.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (student != null)
            {
                ModelState.AddModelError("", "Student already exist");
                return StatusCode(442, ModelState);
            }*/

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newStudent = StudentDtoMapper.ToStudent(createStudent);

            if (!_studentRepository.CreateStudent(newStudent))
            {
                ModelState.AddModelError("", "Somesing went wrong");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfull created");
        }

    }
}
