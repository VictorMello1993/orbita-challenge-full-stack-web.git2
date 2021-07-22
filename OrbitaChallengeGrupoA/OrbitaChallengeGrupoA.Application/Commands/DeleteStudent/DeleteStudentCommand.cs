using MediatR;

namespace OrbitaChallengeGrupoA.Application.Commands.DeleteStudent
{
    public class DeleteStudentCommand : IRequest<Unit>
    {
        public DeleteStudentCommand(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
