namespace OrbitaChallengeGrupoA.Application.DTOs.ViewModels
{
    public class StudentViewModel
    {
        public StudentViewModel(int id, string name, string email, string aR, string cPF)
        {
            Id = id;
            Name = name;
            Email = email;
            AR = aR;
            CPF = cPF;
        }

        public int Id { get; private set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string AR { get; set; }
        public string CPF { get; set; }
    }
}
