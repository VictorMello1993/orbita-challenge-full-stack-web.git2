using MediatR;
using OrbitaChallengeGrupoA.Domain.Exceptions;
using OrbitaChallengeGrupoA.Domain.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OrbitaChallengeGrupoA.Application.Commands.DeleteStudent
{
    public class DeleteStudentCommandHandler : IRequestHandler<DeleteStudentCommand, Unit>
    {
        private readonly IStudentRepository _studentRepository;

        public DeleteStudentCommandHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<Unit> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var student = await _studentRepository.GetByIdAsync(request.Id);

                _studentRepository.Remove(student);

                await _studentRepository.SaveChangesAsync();

                return Unit.Value;
            }
            catch (Exception)
            {
                throw new StudentNotFoundException();
            }
        }
    }
}
