using Moq;
using OrbitaChallengeGrupoA.Application.Queries.GetAllUsers;
using OrbitaChallengeGrupoA.Domain.Entities;
using OrbitaChallengeGrupoA.Domain.Repositories;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace OrbitaChallengeGrupoATests.Application.Queries.GetAllUsers
{
    public class GetAllUsersQueryHandlerTests
    {
        [Fact]
        public async Task ThreeUsersExsist_Executed_ReturnThreeUsersViewModel()
        {
            //Arrange
            var users = new List<User>
            {
                new User("usuario1", "usuario1@gmail.com", "112233"),
                new User("usuario2", "usuario1@gmail.com", "224466"),
                new User("usuario3", "usuario1@gmail.com", "667788")
            };

            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(s => s.GetAllAsync().Result).Returns(users);

            var usersQuery = new GetAllUsersQuery();
            var usersQueryHandler = new GetAllUsersQueryHandler(userRepositoryMock.Object);

            //Act
            var usersViewModel = await usersQueryHandler.Handle(usersQuery, new CancellationToken());

            //Assert
            Assert.NotNull(usersViewModel);
            Assert.NotEmpty(usersViewModel);
            Assert.Equal(users.Count, usersViewModel.Count);

            userRepositoryMock.Verify(s => s.GetAllAsync(), Times.Once, "A lista possui menos ou mais de 3 usuários");
        }
    }
}
