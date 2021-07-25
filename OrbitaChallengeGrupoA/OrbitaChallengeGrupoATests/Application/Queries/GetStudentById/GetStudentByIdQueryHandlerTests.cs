using Moq;
using OrbitaChallengeGrupoA.Application.Queries.GetStudentById;
using OrbitaChallengeGrupoA.Domain.Entities;
using OrbitaChallengeGrupoA.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace OrbitaChallengeGrupoATests.Application.Queries.GetStudentById
{
    public class GetStudentByIdQueryHandlerTests
    {
        [Fact]
        public async Task StudentWithIdExists_Executed_ReturnStudentViewModel()
        {
            //Arrange
            var student = new Student("aluno1", "aluno1@gmail.com", "112233", "11122233344");

            var studentRepositoryMock = new Mock<IStudentRepository>();

            var id = 4;

            var getStudentByIdQuery = new GetStudentByIdQuery(id);
            var getStudentByIdQueryHandler = new GetStudentByIdQueryHandler(studentRepositoryMock.Object);

            studentRepositoryMock.Setup(u => u.GetByIdAsync(getStudentByIdQuery.Id).Result).Returns(student);

            //Act
            var studentViewModel = await getStudentByIdQueryHandler.Handle(getStudentByIdQuery, new CancellationToken());

            //Assert
            Assert.NotNull(studentViewModel);

            studentRepositoryMock.Verify(pr => pr.GetByIdAsync(It.IsAny<int>()), Times.Once, "Aluno não encontrado");
        }
    }
}
