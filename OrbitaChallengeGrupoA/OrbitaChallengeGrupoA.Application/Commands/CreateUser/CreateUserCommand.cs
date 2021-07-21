using MediatR;

namespace OrbitaChallengeGrupoA.Application.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
