using System;

namespace OrbitaChallengeGrupoA.Domain.Exceptions
{
    [Serializable]
    public class ARMustBeUniqueException : Exception
    {
        public ARMustBeUniqueException() : base("Já existe um aluno com a matrícula informada")
        {

        }
    }
}
