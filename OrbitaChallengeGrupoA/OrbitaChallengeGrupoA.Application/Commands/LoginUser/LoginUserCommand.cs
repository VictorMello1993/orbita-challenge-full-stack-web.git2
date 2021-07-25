using MediatR;
using OrbitaChallengeGrupoA.Application.DTOs.ViewModels;

namespace OrbitaChallengeGrupoA.Application.Commands.LoginUser
{
    public class LoginUserCommand : IRequest<LoginUserViewModel>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
