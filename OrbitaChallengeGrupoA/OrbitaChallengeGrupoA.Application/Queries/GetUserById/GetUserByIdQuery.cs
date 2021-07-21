using MediatR;
using OrbitaChallengeGrupoA.Application.DTOs.ViewModels;

namespace OrbitaChallengeGrupoA.Application.Queries.GetUserById
{
    public class GetUserByIdQuery : IRequest<UserViewModel>
    {
        public GetUserByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
