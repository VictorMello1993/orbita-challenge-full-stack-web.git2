using System;

namespace OrbitaChallengeGrupoA.Domain.Exceptions
{
    [Serializable]
    public class CPFMustBeUniqueException : Exception
    {
        public CPFMustBeUniqueException() : base("CPF deve ser único por aluno")
        {

        }
    }
}
