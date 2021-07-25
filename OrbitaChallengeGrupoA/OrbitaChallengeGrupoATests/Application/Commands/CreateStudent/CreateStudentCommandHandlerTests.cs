using Moq;
using OrbitaChallengeGrupoA.Application.Commands.CreateStudent;
using OrbitaChallengeGrupoA.Domain.Entities;
using OrbitaChallengeGrupoA.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace OrbitaChallengeGrupoATests.Application.Commands.CreateStudent
{
    public class CreateStudentCommandHandlerTests
    {
        [Fact]
        public async Task InputDataIsOk_Executed_ReturnStudentId()
        {
            //Arrange
            var studentRepositoryMock = new Mock<IStudentRepository>();

            var createStudentCommand = new CreateStudentCommand
            {
                Name = "aluno1",
                Email = "aluno1@gmail.com",
                AR = "112233",
                CPF = "11122233344",
            };

            var createStudenCommandHandler = new CreateStudentCommandHandler(studentRepositoryMock.Object);

            //Act
            var id = await createStudenCommandHandler.Handle(createStudentCommand, new CancellationToken());

            //Assert
            Assert.True(id >= 0);

            studentRepositoryMock.Verify(s => s.AddAsync(It.IsAny<Student>()), Times.Once, "Não foi possível adicionar aluno");
            studentRepositoryMock.Verify(s => s.SaveChangesAsync(), Times.Once, "Não foi possível confirmar as alterações");
        }
    }
}
