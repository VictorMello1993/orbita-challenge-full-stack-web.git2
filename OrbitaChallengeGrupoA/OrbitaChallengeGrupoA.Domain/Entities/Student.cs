using System;

namespace OrbitaChallengeGrupoA.Domain.Entities
{
    public class Student : BaseEntity
    {
        public Student(string name, string email, string aR, string cPF)
        {
            Name = name;
            Email = email;
            AR = aR;
            CPF = cPF;
        }

        public string Name { get; private set; }
        public string Email { get; private set; }
        public string AR { get; private set; }
        public string CPF { get; private set; }        
        public DateTime UpdatedAt { get; private set; }        

        public void Update(string name, string email)
        {
            Name = name;
            Email = email;
            UpdatedAt = DateTime.Now;
        }
    }
}
