using OrbitaChallengeGrupoA.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrbitaChallengeGrupoA.Domain.Repositories
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetAllAsync();
        Task<Student> GetByIdAsync(int id);
        Task<bool> ExistsByARAsync(string AR);        
        Task<bool> ExistsByCPFAsync(string CPF);        
        Task SaveChangesAsync();
        Task AddAsync(Student student);
        void Remove(Student student);
    }
}
