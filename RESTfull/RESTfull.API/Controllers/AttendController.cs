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
    public class AttendController : ControllerBase
    {

        private readonly InterfaceAttend _attendRepository;

        public AttendController(InterfaceAttend attendRepository)
        {
            _attendRepository = attendRepository;
        }

        [HttpGet]
        public ICollection<Attendance> GetAttends()
        {
            var attends = _attendRepository.GetAttends();
            return attends;
        }


        [HttpGet("{id:Guid}")]
        public IActionResult GetAttend(Guid id)
        {
            var attend = _attendRepository.GetAttend(id);

            if (attend == null)
            {
                // Если студент не найден, возвращаем статус 404 (Not Found)
                return NotFound();
            }

            var attendDto = AttendDtoMapper.ToDto(attend);
            return Ok(attendDto);
        }

        [HttpGet("[action]/{studentId}")]
        public IActionResult GetAttendsByStudentId(Guid studentId)
        {
            var attend = _attendRepository.GetAttendsByStudentId(studentId);

            if (attend == null)
            {
                // Если студент не найден, возвращаем статус 404 (Not Found)
                return NotFound();
            }

            //var attendDto = AttendDtoMapper.ToDto(attend);
            return Ok(attend);
        }

        [HttpPost]
        public IActionResult CreateAttend([FromBody] AttendDto createAttend)
        {
            if (createAttend == null)
            {
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newAttend = AttendDtoMapper.ToAttend(createAttend);

            if (!_attendRepository.CreateAttend(newAttend))
            {
                ModelState.AddModelError("", "Something went wrong");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfull created");
        }


        [HttpPut("{attendId}")]
        public IActionResult UpdateAttend(Guid attendId, [FromBody] AttendDtoWithId updateAttend)
        {
            if(updateAttend == null)
            {
                return BadRequest(ModelState);
            }

            if(attendId != updateAttend.Id)
            {
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var changeAttend = AttendDtoMapper.ToAttendWithId(updateAttend);

            if (!_attendRepository.UpdateAttend(changeAttend))
            {
                ModelState.AddModelError("", "Something went wrong");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{attendId}")]
        public IActionResult DeleteAttend(Guid attendId)
        {
            if (!_attendRepository.AttendExist(attendId))
            {
                return NotFound();
            }

            var removeAttend = _attendRepository.GetAttend(attendId);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_attendRepository.DeleteAttend(removeAttend))
            {
                ModelState.AddModelError("", "Something went wrong");
               
            }

            return NoContent();
        }

    }
}
