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
    public class ClassController : ControllerBase
    {

        private readonly InterfaceClass _classRepository;

        public ClassController(InterfaceClass classRepository)
        {
            _classRepository = classRepository;
        }


        ////////////////////////
        [HttpGet]
        public ICollection<Class> GetClass()
        {
            var clas = _classRepository.GetClasses();
            return clas;
        }

        ////////////////////////
        [HttpGet("{id:Guid}")]
        public IActionResult GetClass(Guid id)
        {
            var clas = _classRepository.GetClass(id);

            if (clas == null)
            {
                return NotFound();
            }

            var classDto = ClassDtoMapper.ToDto(clas);
            return Ok(classDto);
        }

        ////////////////////////
        [HttpGet("getClassByName/{name}")]
        public IActionResult GetClassByName(string name)
        {
            var clas = _classRepository.GetClassByName(name);
            if (clas == null)
            {
                return NotFound();
            }
            var classDto = ClassDtoMapper.ToDtoList(clas);
            return Ok(classDto);
        }

        [HttpGet("[action]/{attends}")]
        public IActionResult GetClassByAttend(ICollection<Attendance> attends)
        {
            var clas = _classRepository.GetClassesByAttends(attends);

            if (clas == null)
            {
                return NotFound();
            }

            //var classDto = ClassDtoMapper.ToDtoList(clas);
            return Ok(clas);
        }

        ////////////////////////
        [HttpPost]
        public IActionResult CreateClass([FromBody] ClassDto createClass)
        {
            if (createClass == null)
            {
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newClass = ClassDtoMapper.ToClass(createClass);

            if (!_classRepository.CreateClass(newClass))
            {
                ModelState.AddModelError("", "Something went wrong");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfull created");
        }

        ////////////////////////
        [HttpPut("{classId}")]
        public IActionResult UpdateClass(Guid classId, [FromBody] ClassDtoWithId updateClass)
        {
            if (updateClass == null)
            {
                return BadRequest(ModelState);
            }

            if (classId != updateClass.Id)
            {
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var changeClass = ClassDtoMapper.ToClassWithId(updateClass); 

            if (!_classRepository.UpdateClass(changeClass))
            {
                ModelState.AddModelError("", "Something went wrong");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }


        ////////////////////////
        [HttpDelete("{classId}")]
        public IActionResult DeleteClass(Guid classId)
        {
            if (!_classRepository.ClassExist(classId))
            {
                return NotFound();
            }

            var removeClass = _classRepository.GetClass(classId);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_classRepository.DeleteClass(removeClass))
            {
                ModelState.AddModelError("", "Something went wrong");

            }

            return NoContent();
        }

    }
}
