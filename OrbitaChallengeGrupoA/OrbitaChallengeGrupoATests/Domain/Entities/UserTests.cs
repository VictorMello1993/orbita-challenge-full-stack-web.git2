using OrbitaChallengeGrupoA.Domain.Entities;
using System;
using Xunit;

namespace OrbitaChallengeGrupoATests.Domain.Entities
{
    public class UserTests
    {
        [Fact]
        private void TestIfUpdateUserWorks()
        {
            var user = new User("user1", "user1@gmail.com", "12345678");

            Assert.True(user.Active);
            Assert.Equal(DateTime.Now.Date, user.CreatedAt.Date);
            Assert.Equal(DateTime.MinValue, user.UpdatedAt);
            Assert.NotEqual(string.Empty, user.Name);
            Assert.NotEqual(string.Empty, user.Email);
            Assert.NotEqual(string.Empty, user.Password);
            Assert.Equal(8, user.Password.Length);

            user.Update("user2", "user2@gmail.com", "45678901");

            Assert.Equal("user2", user.Name);
            Assert.Equal("user2@gmail.com", user.Email);
            Assert.Equal("45678901", user.Password);
            Assert.NotEqual(DateTime.MinValue, user.UpdatedAt);
            Assert.Equal(DateTime.Now.Date, user.UpdatedAt.Date);
        }

        [Fact]
        private void TestIfInactivateUserWorks()
        {
            var user = new User("user1", "user1@gmail.com", "12345678");

            Assert.True(user.Active);
            Assert.Equal(DateTime.Now.Date, user.CreatedAt.Date);
            Assert.Equal(DateTime.MinValue, user.UpdatedAt);
            Assert.NotEqual(string.Empty, user.Name);
            Assert.NotEqual(string.Empty, user.Email);
            Assert.NotEqual(string.Empty, user.Password);
            Assert.Equal(8, user.Password.Length);

            user.Delete();

            Assert.False(user.Active);
        }
    }
}
