using System;

namespace OrbitaChallengeGrupoA.Domain.Exceptions
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException() : base("Usuário não cadastrado")
        {

        }
    }
}
