using MediatR;
using OrbitaChallengeGrupoA.Application.DTOs.ViewModels;
using OrbitaChallengeGrupoA.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace OrbitaChallengeGrupoA.Application.Queries.GetStudentById
{
    public class GetStudentByIdQueryHandler : IRequestHandler<GetStudentByIdQuery, StudentViewModel>
    {
        private readonly IStudentRepository _studentRepository;

        public GetStudentByIdQueryHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<StudentViewModel> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            var student = await _studentRepository.GetByIdAsync(request.Id);

            if(student == null)
            {
                return null;
            }

            var studentViewModel = new StudentViewModel(student.Id, student.Name, student.Email, student.AR, student.CPF);

            return studentViewModel;
        }
    }
}
