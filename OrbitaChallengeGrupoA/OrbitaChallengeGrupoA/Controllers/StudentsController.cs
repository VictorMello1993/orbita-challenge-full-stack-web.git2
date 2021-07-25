using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrbitaChallengeGrupoA.Application.Commands.CreateStudent;
using OrbitaChallengeGrupoA.Application.Commands.DeleteStudent;
using OrbitaChallengeGrupoA.Application.Commands.UpdateStudent;
using OrbitaChallengeGrupoA.Application.DTOs.InputModels;
using OrbitaChallengeGrupoA.Application.DTOs.ViewModels;
using OrbitaChallengeGrupoA.Application.Queries.GetAllStudents;
using OrbitaChallengeGrupoA.Application.Queries.GetStudentById;
using OrbitaChallengeGrupoA.Domain.Exceptions;
using System;
using System.Net;
using System.Threading.Tasks;

namespace OrbitaChallengeGrupoA.Controllers
{
    [Route("api/students")]
    [Authorize]
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

            if (studentViewModel == null)
            {
                var studentNotFoundViewModel = new ErrorViewModel(HttpStatusCode.NotFound, new StudentNotFoundException());

                return NotFound(studentNotFoundViewModel);
            }

            return Ok(studentViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateStudentCommand command)
        {
            try
            {
                var id = await _mediator.Send(command);

                return CreatedAtAction(nameof(GetById), new { Id = id }, command);
            }
            catch (Exception ex)
            {
                var errorViewModel = new ErrorViewModel(HttpStatusCode.BadRequest, ex);

                return BadRequest(errorViewModel);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateStudentInputModel inputModel)
        {
            try
            {
                var command = new UpdateStudentCommand(id, inputModel.Name, inputModel.Email);

                await _mediator.Send(command);                

                return NoContent();
            }
            catch (Exception ex)
            {
                var studentNotFoundViewModel = new ErrorViewModel(HttpStatusCode.NotFound, ex);

                return NotFound(studentNotFoundViewModel);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var command = new DeleteStudentCommand(id);

                await _mediator.Send(command);

                return NoContent();
            }
            catch (Exception ex)
            {
                var studentNotFoundViewModel = new ErrorViewModel(HttpStatusCode.NotFound, ex);

                return NotFound(studentNotFoundViewModel);
            }
        }
    }
}
