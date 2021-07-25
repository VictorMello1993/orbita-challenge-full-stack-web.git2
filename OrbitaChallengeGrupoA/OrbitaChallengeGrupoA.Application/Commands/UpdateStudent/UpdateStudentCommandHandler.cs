using MediatR;
using OrbitaChallengeGrupoA.Domain.Exceptions;
using OrbitaChallengeGrupoA.Domain.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OrbitaChallengeGrupoA.Application.Commands.UpdateStudent
{
    public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand, Unit>
    {
        private readonly IStudentRepository _studentRepository;

        public UpdateStudentCommandHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<Unit> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var student = await _studentRepository.GetByIdAsync(request.Id);

                student.Update(request.Name, request.Email);

                await _studentRepository.SaveChangesAsync();

                return Unit.Value;
            }
            catch(Exception)
            {
                throw new StudentNotFoundException();
            }
        }
    }
}
