using Moq;
using OrbitaChallengeGrupoA.Application.Queries.GetAllStudents;
using OrbitaChallengeGrupoA.Domain.Entities;
using OrbitaChallengeGrupoA.Domain.Repositories;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace OrbitaChallengeGrupoATests.Application.Queries.GetAllStudents
{
    public class GetAllStudentsQueryHandlerTests
    {
        [Fact]
        public async Task ThreeStudentsExist_Executed_ReturnThreeStudentsViewModels()
        {
            //Arrange
            var students = new List<Student>
            {
                new Student("aluno1", "aluno1@gmail.com", "112233", "11122233344"),
                new Student("aluno2", "aluno2@gmail.com", "224466", "22233344455"),
                new Student("aluno3", "aluno3@gmail.com", "667788", "66677788899")
            };

            var studentRepositoryMock = new Mock<IStudentRepository>();
            studentRepositoryMock.Setup(s => s.GetAllAsync().Result).Returns(students);

            var studentQuery = new GetAllStudentsQuery();
            var studentsQueryHandler = new GetAllStudentsQueryHandler(studentRepositoryMock.Object);

            //Act
            var studentViewModel = await studentsQueryHandler.Handle(studentQuery, new CancellationToken());

            //Assert
            Assert.NotNull(studentViewModel);
            Assert.NotEmpty(studentViewModel);
            Assert.Equal(students.Count, studentViewModel.Count);

            studentRepositoryMock.Verify(s => s.GetAllAsync().Result, Times.Once);
        }
    }
}
