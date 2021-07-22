using MediatR;

namespace OrbitaChallengeGrupoA.Application.Commands.UpdateStudent
{
    public class UpdateStudentCommand : IRequest<Unit>
    {
        public UpdateStudentCommand(int id, string name, string email)
        {
            Id = id;
            Name = name;
            Email = email;
        }

        public int Id { get; private set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
