using Microsoft.EntityFrameworkCore;
using OrbitaChallengeGrupoA.Domain.Entities;
using OrbitaChallengeGrupoA.Domain.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrbitaChallengeGrupoA.Infrastructure.Persistence.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly OrbitaChallengeGrupoADbContext _dbContext;

        public StudentRepository(OrbitaChallengeGrupoADbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Student student)
        {
            await _dbContext.Students.AddAsync(student);
        }

        public async Task<bool> ExistsByARAsync(string AR)
        {
            return await _dbContext.Students.CountAsync(s => s.AR == AR) > 0;
        }

        public async Task<bool> ExistsByCPFAsync(string CPF)
        {
            return await _dbContext.Students.CountAsync(s => s.CPF == CPF) > 0;
        }

        public async Task<List<Student>> GetAllAsync()
        {
            return await _dbContext.Students.ToListAsync();
        }

        public async Task<Student> GetByIdAsync(int id)
        {
            return await _dbContext.Students.SingleOrDefaultAsync(s => s.Id == id);
        }

        public void Remove(Student student)
        {
            _dbContext.Students.Remove(student);
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
