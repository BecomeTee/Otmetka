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
       // [ProducesResponseType(200, Type = typeof(StudentDto))]
        public StudentDto GetStudent(Guid id)
        {
            var student = _studentRepository.GetStudent(id);
            /*if (student == null)
            {
                return NotFound();
            }*/
            var studentDto = StudentDtoMapper.ToDto(student);
            return studentDto;
        }




        // GET: api/<StudController>
        /*[HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<StudController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<StudController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<StudController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<StudController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }*/
    }
}
