using System;

namespace OrbitaChallengeGrupoA.Domain.Exceptions
{
    [Serializable]
    public class StudentNotFoundException : Exception
    {
        public StudentNotFoundException() : base("Aluno(a) não cadastrado(a)")
        {

        }
    }
}
