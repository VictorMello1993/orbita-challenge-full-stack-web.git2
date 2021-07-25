namespace OrbitaChallengeGrupoA.Application.DTOs.ViewModels
{
    public class NewLoginUserViewModel
    {
        public NewLoginUserViewModel(string email, string token)
        {
            Email = email;
            Token = token;
        }

        public string Email { get; private set; }
        public string Token { get; private set; }
    }
}
