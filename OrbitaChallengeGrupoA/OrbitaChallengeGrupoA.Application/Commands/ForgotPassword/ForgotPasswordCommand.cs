using MediatR;
using OrbitaChallengeGrupoA.Application.DTOs.ViewModels;

namespace OrbitaChallengeGrupoA.Application.Commands
{
    public class ForgotPasswordCommand : IRequest<NewLoginUserViewModel>
    {
        public string Email { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmNewPassword { get; set; }
    }
}
