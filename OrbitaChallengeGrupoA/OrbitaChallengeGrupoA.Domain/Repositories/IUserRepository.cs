using OrbitaChallengeGrupoA.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrbitaChallengeGrupoA.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllAsync();
        Task AddAsync(User user);
        Task<User> GetByIdAsync(int id);
        Task SaveChangesAsync();
        Task<User> GetByEmailAndPasswordAsync(string email, string password);
        Task<User> GetByEmailAsync(string email);
    }
}
