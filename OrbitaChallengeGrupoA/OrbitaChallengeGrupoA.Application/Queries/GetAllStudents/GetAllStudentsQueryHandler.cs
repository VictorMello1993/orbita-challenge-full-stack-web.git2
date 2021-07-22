using MediatR;
using OrbitaChallengeGrupoA.Application.DTOs.ViewModels;
using OrbitaChallengeGrupoA.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OrbitaChallengeGrupoA.Application.Queries.GetAllStudents
{
    public class GetAllStudentsQueryHandler : IRequestHandler<GetAllStudentsQuery, List<StudentViewModel>>
    {
        private readonly IStudentRepository _studentRepository;

        public GetAllStudentsQueryHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<List<StudentViewModel>> Handle(GetAllStudentsQuery request, CancellationToken cancellationToken)
        {
            var students = await _studentRepository.GetAllAsync();

            if(students == null)
            {
                return null;
            }

            var studentsViewModel = students.Select(s => new StudentViewModel(s.Id, s.Name, s.Email, s.AR, s.CPF)).ToList();

            return studentsViewModel;
        }
    }
}
