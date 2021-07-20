using System;

namespace OrbitaChallengeGrupoA.Domain.Entities
{
    public abstract class BaseEntity
    {
        protected BaseEntity()
        {
            CreatedAt = DateTime.Now;            
        }        

        public int Id { get; private set; }
        public DateTime CreatedAt { get; private set; }                
    }
}
