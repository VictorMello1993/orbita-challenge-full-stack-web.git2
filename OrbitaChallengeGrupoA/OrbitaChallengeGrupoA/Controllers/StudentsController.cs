using MediatR;
using Microsoft.AspNetCore.Mvc;
using OrbitaChallengeGrupoA.Application.Commands.CreateStudent;
using OrbitaChallengeGrupoA.Application.Commands.DeleteStudent;
using OrbitaChallengeGrupoA.Application.Commands.UpdateStudent;
using OrbitaChallengeGrupoA.Application.DTOs.InputModels;
using OrbitaChallengeGrupoA.Application.Queries.GetAllStudents;
using OrbitaChallengeGrupoA.Application.Queries.GetStudentById;
using OrbitaChallengeGrupoA.Domain.Entities;
using OrbitaChallengeGrupoA.Domain.Repositories;
using System.Threading.Tasks;

namespace OrbitaChallengeGrupoA.Controllers
{
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StudentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllStudentsQuery();

            var studentsViewModel = await _mediator.Send(query);

            return Ok(studentsViewModel);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetStudentByIdQuery(id);

            var studentViewModel = await _mediator.Send(query);

            if(studentViewModel == null)
            {
                return NotFound();
            }

            return Ok(studentViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateStudentCommand command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { Id = id}, command);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateStudentInputModel inputModel)
        {
            var command = new UpdateStudentCommand(id, inputModel.Name, inputModel.Email);

            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteStudentCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }
    }
}
