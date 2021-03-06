using OrbitaChallengeGrupoA.Domain.Exceptions;
using System;

namespace OrbitaChallengeGrupoA.Domain.Entities
{
    public class User : BaseEntity
    {
        public User(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
            Active = true;
        }

        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public DateTime UpdatedAt { get; private set; }
        public bool Active { get; private set; }

        public void Update(string name, string email, string passwordHash = "")
        {
            if (!Active)
            {
                throw new UserInactiveException();
            }

            Name = name;
            Email = email;
            UpdatedAt = DateTime.Now;
            Password = passwordHash;
        }

        public void Delete()
        {
            if (!Active)
            {
                throw new UserInactiveException();
            }

            Active = false;
        }
    }
}
