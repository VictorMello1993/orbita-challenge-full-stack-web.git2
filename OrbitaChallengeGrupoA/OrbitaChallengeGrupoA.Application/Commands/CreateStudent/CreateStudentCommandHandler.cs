using MediatR;
using OrbitaChallengeGrupoA.Domain.Entities;
using OrbitaChallengeGrupoA.Domain.Exceptions;
using OrbitaChallengeGrupoA.Domain.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OrbitaChallengeGrupoA.Application.Commands.CreateStudent
{
    public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, int>
    {
        private readonly IStudentRepository _studentRepository;

        public CreateStudentCommandHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<int> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var student = new Student(request.Name, request.Name, request.AR, request.CPF);

                var existsStudentsByAR = await _studentRepository.ExistsByARAsync(request.AR);
                var existsStudentsByCPF = await _studentRepository.ExistsByCPFAsync(request.CPF);

                if (!existsStudentsByAR && !existsStudentsByCPF)
                {
                    await _studentRepository.AddAsync(student);
                    await _studentRepository.SaveChangesAsync();
                }
                else if(existsStudentsByAR)
                {
                    throw new ARMustBeUniqueException();
                }
                else if (existsStudentsByCPF)
                {
                    throw new CPFMustBeUniqueException();
                }

                return student.Id;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
