using OrbitaChallengeGrupoA.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrbitaChallengeGrupoA.Domain.Repositories
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetAllAsync();
        Task<Student> GetByIdAsync(int id);        
        Task SaveChangesAsync();
        Task AddAsync(Student student);
        void Remove(Student student);
    }
}
