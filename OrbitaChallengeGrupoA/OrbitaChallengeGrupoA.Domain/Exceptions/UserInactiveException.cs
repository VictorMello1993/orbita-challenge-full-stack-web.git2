using System;

namespace OrbitaChallengeGrupoA.Domain.Exceptions
{
    public class UserInactiveException : Exception
    {
        public UserInactiveException() : base("The user is already inactive")
        {

        }
    }
}
