using MediatR;
using Microsoft.AspNetCore.Mvc;
using OrbitaChallengeGrupoA.Application.Commands.CreateUser;
using OrbitaChallengeGrupoA.Application.Commands.DeleteUser;
using OrbitaChallengeGrupoA.Application.Commands.UpdateUser;
using OrbitaChallengeGrupoA.Application.DTOs.InputModels;
using OrbitaChallengeGrupoA.Application.DTOs.ViewModels;
using OrbitaChallengeGrupoA.Application.Queries.GetAllUsers;
using OrbitaChallengeGrupoA.Application.Queries.GetUserById;
using OrbitaChallengeGrupoA.Domain.Exceptions;
using System;
using System.Net;
using System.Threading.Tasks;

namespace OrbitaChallengeGrupoA.API.Controllers
{
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllUsersQuery();

            var usersViewModel = await _mediator.Send(query);

            if (usersViewModel == null)
                return NotFound();

            return Ok(usersViewModel);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetUserByIdQuery(id);

            var userViewModel = await _mediator.Send(query);

            if (userViewModel == null)
            {
                var userNotFoundViewModel = new ErrorViewModel(HttpStatusCode.NotFound, new UserNotFoundException());

                return NotFound(userNotFoundViewModel);
            }

            return Ok(userViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateUserCommand command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { Id = id }, command);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateUserInputModel inputModel)
        {
            try
            {
                var command = new UpdateUserCommand(id, inputModel.Name, inputModel.Email);

                await _mediator.Send(command);

                return NoContent();
            }
            catch (Exception ex)
            {
                var userNotFoundViewModel = new ErrorViewModel(HttpStatusCode.NotFound, ex);

                return NotFound(userNotFoundViewModel);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var command = new DeleteUserCommand(id);

                await _mediator.Send(command);

                return NoContent();

            }
            catch (Exception ex)
            {
                var userNotFoundViewModel = new ErrorViewModel(HttpStatusCode.NotFound, ex);

                return NotFound(userNotFoundViewModel);
            }
        }
    }
}
