using MediatR;
using OrbitaChallengeGrupoA.Application.DTOs.ViewModels;

namespace OrbitaChallengeGrupoA.Application.Queries.GetStudentById
{
    public class GetStudentByIdQuery : IRequest<StudentViewModel>
    {
        public GetStudentByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
