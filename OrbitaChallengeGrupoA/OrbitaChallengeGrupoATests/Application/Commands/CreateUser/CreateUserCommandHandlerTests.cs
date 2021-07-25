using Moq;
using OrbitaChallengeGrupoA.Application.Commands.CreateUser;
using OrbitaChallengeGrupoA.Domain.Entities;
using OrbitaChallengeGrupoA.Domain.Repositories;
using OrbitaChallengeGrupoA.Domain.Services.Auth;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace OrbitaChallengeGrupoATests.Application.Commands.CreateUser
{
    public class CreateUserCommandHandlerTests 
    {
        [Fact]
        public async Task InputDataIsOk_Executed_ReturnUserId()
        {
            //Arrange
            var userRepositoryMock = new Mock<IUserRepository>();
            var authServiceMock = new Mock<IAuthService>();

            var createUserCommand = new CreateUserCommand
            {
                Name = "user1",
                Email = "user1@gmail.com",
                Password = "123456"
            };

            var createUserCommandHandler = new CreateUserCommandHandler(userRepositoryMock.Object, authServiceMock.Object);

            //Act
            var id = await createUserCommandHandler.Handle(createUserCommand, new CancellationToken());

            //Assert
            Assert.True(id >= 0);

            userRepositoryMock.Verify(u => u.AddAsync(It.IsAny<User>()), Times.Once, "Não foi possível adicionar usuário");
            userRepositoryMock.Verify(u => u.SaveChangesAsync(), Times.Once, "Não foi possível confirmar as alterações");
        }
    }
}
