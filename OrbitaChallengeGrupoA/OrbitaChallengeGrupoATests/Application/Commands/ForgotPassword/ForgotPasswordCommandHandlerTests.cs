using Moq;
using OrbitaChallengeGrupoA.Application.Commands;
using OrbitaChallengeGrupoA.Application.Commands.ForgotPassword;
using OrbitaChallengeGrupoA.Domain.Entities;
using OrbitaChallengeGrupoA.Domain.Repositories;
using OrbitaChallengeGrupoA.Domain.Services.Auth;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace OrbitaChallengeGrupoATests.Application.Commands.ForgotPassword
{
    public class ForgotPasswordCommandHandlerTests
    {
        [Fact]
        public async Task InputDataIsOk_Executed_RedeemNewPassword()
        {
            //Arrange
            var forgotPasswordCommand = new ForgotPasswordCommand
            {
                Email = "user@gmail.com",
                NewPassword = "445566",
                ConfirmNewPassword = "445566"
            };

            var user = new User("user1", forgotPasswordCommand.Email, "123456");
            var token = "asdsadfsafiugsafuiasf8878977sda";

            var authServiceMock = new Mock<IAuthService>();
            var userRepositoryMock = new Mock<IUserRepository>();

            var forgotPasswordCommandHandler = new ForgotPasswordCommandHandler(userRepositoryMock.Object, authServiceMock.Object);

            authServiceMock.Setup(u => u.ComputeSha256Hash(forgotPasswordCommand.ConfirmNewPassword)).Returns(forgotPasswordCommand.ConfirmNewPassword);
            authServiceMock.Setup(u => u.GenerateJWTToken(forgotPasswordCommand.Email)).Returns(token);
            userRepositoryMock.Setup(u => u.GetByEmailAsync(forgotPasswordCommand.Email).Result).Returns(user);

            //Act
            var newLoginUserViewModel = await forgotPasswordCommandHandler.Handle(forgotPasswordCommand, new CancellationToken());

            //Assert
            Assert.NotNull(newLoginUserViewModel);

            userRepositoryMock.Verify(u => u.GetByEmailAsync(It.IsAny<string>()), Times.Once, "Usuário não encontrado");
            authServiceMock.Verify(u => u.ComputeSha256Hash(It.IsAny<string>()), Times.Once, "Não foi possível encriptar a senha");
            authServiceMock.Verify(u => u.GenerateJWTToken(It.IsAny<string>()), Times.Once, "Não foi possível gerar token JWT");
        }
    }
}
