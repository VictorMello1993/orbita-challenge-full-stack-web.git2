using System;

namespace OrbitaChallengeGrupoA.Domain.Exceptions
{
    public class InvalidLoginException : Exception
    {
        public InvalidLoginException() : base("Email ou senha inválidos.")
        {

        }
    }
}
