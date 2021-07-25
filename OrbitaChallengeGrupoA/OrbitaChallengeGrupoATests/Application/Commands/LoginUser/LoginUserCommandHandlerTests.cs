using Moq;
using OrbitaChallengeGrupoA.Application.Commands.LoginUser;
using OrbitaChallengeGrupoA.Domain.Entities;
using OrbitaChallengeGrupoA.Domain.Repositories;
using OrbitaChallengeGrupoA.Domain.Services.Auth;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace OrbitaChallengeGrupoATests.Application.Commands.LoginUser
{
    public class LoginUserCommandHandlerTests
    {
        [Fact]
        public async Task InputDataIsOk_Executed_ReturnLoginUserViewModel()
        {
            //Arrange
            var loginUserCommand = new LoginUserCommand
            {
                Email = "user@gmail.com",
                Password = "123456"
            };

            var user = new User("user1", loginUserCommand.Email, loginUserCommand.Password);
            var token = "sadhgusadgyasda46sa564f564456saf4";

            var authServiceMock = new Mock<IAuthService>();
            var userRepositoryMock = new Mock<IUserRepository>();

            var loginUserCommandHandler = new LoginUserCommandHandler(authServiceMock.Object, userRepositoryMock.Object);

            authServiceMock.Setup(u => u.ComputeSha256Hash(loginUserCommand.Password)).Returns(loginUserCommand.Password);
            authServiceMock.Setup(u => u.GenerateJWTToken(loginUserCommand.Email)).Returns(token);
            userRepositoryMock.Setup(u => u.GetByEmailAndPasswordAsync(loginUserCommand.Email, loginUserCommand.Password).Result).Returns(user);

            //Act
            var loginUserViewModel = await loginUserCommandHandler.Handle(loginUserCommand, new CancellationToken());

            //Assert
            Assert.NotNull(loginUserViewModel);

            userRepositoryMock.Verify(u => u.GetByEmailAndPasswordAsync(It.IsAny<string>(), It.IsAny<string>()), Times.Once, "Usuário não encontrado");
            authServiceMock.Verify(u => u.ComputeSha256Hash(It.IsAny<string>()), Times.Once, "Não foi possível encriptar a senha");
            authServiceMock.Verify(u => u.GenerateJWTToken(It.IsAny<string>()), Times.Once, "Não foi possível gerar token JWT");
        }
    }
}
