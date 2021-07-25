using MediatR;
using OrbitaChallengeGrupoA.Application.DTOs.ViewModels;
using OrbitaChallengeGrupoA.Domain.Repositories;
using OrbitaChallengeGrupoA.Domain.Services.Auth;
using System.Threading;
using System.Threading.Tasks;

namespace OrbitaChallengeGrupoA.Application.Commands.ForgotPassword
{
    public class ForgotPasswordCommandHandler : IRequestHandler<ForgotPasswordCommand, NewLoginUserViewModel>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthService _authService;

        public ForgotPasswordCommandHandler(IUserRepository userRepository, IAuthService authService)
        {
            _userRepository = userRepository;
            _authService = authService;
        }

        public async Task<NewLoginUserViewModel> Handle(ForgotPasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByEmailAsync(request.Email);

            if(user == null)
            {
                return null;
            }

            var passwordHash = _authService.ComputeSha256Hash(request.ConfirmNewPassword);

            user.Update(user.Name, user.Email, passwordHash);

            await _userRepository.SaveChangesAsync();

            var token = _authService.GenerateJWTToken(user.Email);

            return new NewLoginUserViewModel(user.Email, token);
        }
    }
}
