using MediatR;
using OrbitaChallengeGrupoA.Application.DTOs.ViewModels;
using OrbitaChallengeGrupoA.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace OrbitaChallengeGrupoA.Application.Queries.GetUserById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserViewModel>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByIdQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserViewModel> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);

            if(user == null)
            {
                return null;
            }

            var userViewModel = new UserViewModel(user.Id, user.Name, user.Email);

            return userViewModel;
        }
    }
}
