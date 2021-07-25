using Moq;
using OrbitaChallengeGrupoA.Application.Commands.DeleteStudent;
using OrbitaChallengeGrupoA.Domain.Entities;
using OrbitaChallengeGrupoA.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace OrbitaChallengeGrupoATests.Application.Commands.DeleteStudent
{
    public class DeleteStudentCommandHandlerTests
    {
        [Fact]
        public async Task StudentExists_Executed_RemoveStudent()
        {
            //Arrange
            var studentRepositoryMock = new Mock<IStudentRepository>();

            var student = new Student("aluno1", "aluno1@gmai.com", "112233", "11122233344");
            var id = 100;

            var deleteStudentCommand = new DeleteStudentCommand(id);
            var deleteStudentCommandHandler = new DeleteStudentCommandHandler(studentRepositoryMock.Object);

            studentRepositoryMock.Setup(s => s.GetByIdAsync(id).Result).Returns(student);

            //Act
            await deleteStudentCommandHandler.Handle(deleteStudentCommand, new CancellationToken());

            //Assert            
            studentRepositoryMock.Verify(s => s.Remove(It.IsNotNull<Student>()), Times.Once, "Aluno não encontrado");
            studentRepositoryMock.Verify(s => s.SaveChangesAsync(), Times.Once, "Não foi possível confirmar as alterações");            
        }
    }
}
