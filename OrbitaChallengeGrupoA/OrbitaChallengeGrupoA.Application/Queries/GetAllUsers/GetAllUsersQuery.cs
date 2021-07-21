using MediatR;
using OrbitaChallengeGrupoA.Application.DTOs.ViewModels;
using System.Collections.Generic;

namespace OrbitaChallengeGrupoA.Application.Queries.GetAllUsers
{
    public class GetAllUsersQuery : IRequest<List<UserViewModel>>
    {
        public GetAllUsersQuery()
        {

        }
    }
}
