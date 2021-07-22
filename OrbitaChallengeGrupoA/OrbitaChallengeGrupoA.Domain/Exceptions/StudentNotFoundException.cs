using System;

namespace OrbitaChallengeGrupoA.Domain.Exceptions
{
    public class StudentNotFoundException : Exception
    {
        public StudentNotFoundException() : base("Student not found")
        {

        }
    }
}
