using MediatR;
using OrbitaChallengeGrupoA.Application.DTOs.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrbitaChallengeGrupoA.Application.Queries.GetAllStudents
{
    public class GetAllStudentsQuery : IRequest<List<StudentViewModel>>
    {
    }
}
