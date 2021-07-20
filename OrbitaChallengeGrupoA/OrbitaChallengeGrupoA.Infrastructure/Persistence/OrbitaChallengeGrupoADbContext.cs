using Microsoft.EntityFrameworkCore;
using OrbitaChallengeGrupoA.Domain.Entities;

namespace OrbitaChallengeGrupoA.Infrastructure.Persistence
{
    public class OrbitaChallengeGrupoADbContext : DbContext
    {
        public OrbitaChallengeGrupoADbContext(DbContextOptions<OrbitaChallengeGrupoADbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(u => u.Id);
            modelBuilder.Entity<Student>().HasKey(s => s.Id);

            modelBuilder.Entity<Student>().HasIndex(u => u.AR).IsUnique();
            modelBuilder.Entity<Student>().HasIndex(u => u.CPF).IsUnique();
        }
    }
}
