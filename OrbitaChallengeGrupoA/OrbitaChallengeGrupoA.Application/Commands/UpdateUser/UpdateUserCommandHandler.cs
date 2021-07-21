using MediatR;
using OrbitaChallengeGrupoA.Domain.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OrbitaChallengeGrupoA.Application.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Unit>
    {
        private readonly IUserRepository _userRepository;

        public UpdateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);

            user.Update(request.Name, request.Email);

            await _userRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
