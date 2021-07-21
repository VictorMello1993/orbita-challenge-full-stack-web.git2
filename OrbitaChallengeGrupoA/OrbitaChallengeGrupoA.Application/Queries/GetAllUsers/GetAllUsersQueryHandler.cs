using MediatR;
using OrbitaChallengeGrupoA.Application.DTOs.ViewModels;
using OrbitaChallengeGrupoA.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OrbitaChallengeGrupoA.Application.Queries.GetAllUsers
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<UserViewModel>>
    {
        private readonly IUserRepository _userRepository;

        public GetAllUsersQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<UserViewModel>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetAllAsync();

            if(users == null)
            {
                return null;
            }

            var usersViewModel = users.Select(u => new UserViewModel(u.Id, u.Name, u.Email)).ToList();

            return usersViewModel;
        }
    }
}
