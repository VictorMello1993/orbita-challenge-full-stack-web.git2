namespace OrbitaChallengeGrupoA.Application.DTOs.InputModels
{
    public class UpdateStudentInputModel
    {
        public UpdateStudentInputModel(int id, string name, string email)
        {
            Id = id;
            Name = name;
            Email = email;
        }

        public int Id { get; private set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
