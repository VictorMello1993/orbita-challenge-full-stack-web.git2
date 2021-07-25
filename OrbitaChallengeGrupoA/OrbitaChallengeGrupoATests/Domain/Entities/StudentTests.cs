using OrbitaChallengeGrupoA.Domain.Entities;
using System;
using Xunit;

namespace OrbitaChallengeGrupoATests.Domain.Entities
{
    public class StudentTests
    {
        [Fact]
        public void TestIfUpdateStudentWorks()
        {
            var student = new Student("aluno1", "aluno1@gmail.com", "112233", "12887401742");

            Assert.Equal(DateTime.Now.Date, student.CreatedAt.Date);
            Assert.Equal(DateTime.MinValue, student.UpdatedAt);
            Assert.NotEqual(string.Empty, student.Name);
            Assert.NotEqual(string.Empty, student.Email);
            Assert.NotEqual(string.Empty, student.AR);
            Assert.NotEqual(string.Empty, student.CPF);
            Assert.Equal(6, student.AR.Length);
            Assert.Equal(11, student.CPF.Length);

            student.Update("aluno2", "aluno2@gmail.com");
            
            Assert.Equal("aluno2", student.Name);
            Assert.Equal("aluno2@gmail.com", student.Email);
            Assert.NotEqual(DateTime.MinValue, student.UpdatedAt);
            Assert.Equal(DateTime.Now.Date, student.UpdatedAt.Date);
        }        
    }
}
