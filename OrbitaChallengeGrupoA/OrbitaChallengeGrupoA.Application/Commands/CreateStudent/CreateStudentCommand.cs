using MediatR;

namespace OrbitaChallengeGrupoA.Application.Commands.CreateStudent
{
    public class CreateStudentCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string AR { get; set; }
        public string CPF { get; set; }
    }
}
