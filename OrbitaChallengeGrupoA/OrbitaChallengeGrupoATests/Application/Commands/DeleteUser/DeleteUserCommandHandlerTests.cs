using Moq;
using OrbitaChallengeGrupoA.Application.Commands.DeleteUser;
using OrbitaChallengeGrupoA.Domain.Entities;
using OrbitaChallengeGrupoA.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace OrbitaChallengeGrupoATests.Application.Commands.DeleteUser
{
    public class DeleteUserCommandHandlerTests
    {
        [Fact]
        public async Task UserExists_Executed_InactivateUser()
        {
            //Arrange
            var userRepositoryMock = new Mock<IUserRepository>();

            var user = new User("aluno1", "aluno1@gmail.com", "1234");
            var id = 100;

            var deleteUserCommand = new DeleteUserCommand(id);
            var deleteUserCommandHandler = new DeleteUserCommandHandler(userRepositoryMock.Object);

            userRepositoryMock.Setup(s => s.GetByIdAsync(id).Result).Returns(user);

            //Act
            await deleteUserCommandHandler.Handle(deleteUserCommand, new CancellationToken());

            //Assert            
            userRepositoryMock.Verify(u => u.GetByIdAsync(id), Times.Once, "Usuário não encontrado");
            userRepositoryMock.Verify(u => u.SaveChangesAsync(), Times.Once, "Não foi possível confirmar as alterações");

        }
    }
}
