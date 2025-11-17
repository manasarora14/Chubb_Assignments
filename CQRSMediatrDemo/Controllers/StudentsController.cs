using CQRSMediatrDemo.Commands.CreateStudent;
using CQRSMediatrDemo.Commands.DeleteStudent;
using CQRSMediatrDemo.Commands.UpdateStudent;
using CQRSMediatrDemo.Requests.GetAllStudents;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRSMediatrDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StudentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // POST: api/students
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStudentCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetAll), new { id }, new { StudentId = id });
        }

        // GET: api/students
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var students = await _mediator.Send(new GetAllStudentsQuery());
            return Ok(students);
        }

        // PUT: api/students/{id}
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateStudentCommand command)
        {
            if (id != command.Id) return BadRequest("Id in path and body must match.");

            var updated = await _mediator.Send(command);
            if (!updated) return NotFound();
            return NoContent();
        }

        // DELETE: api/students/{id}
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _mediator.Send(new DeleteStudentCommand(id));
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
