using Microsoft.AspNetCore.Mvc;
using OrbitaChallengeGrupoA.Application.DTOs.InputModels;
using OrbitaChallengeGrupoA.Domain.Entities;
using OrbitaChallengeGrupoA.Domain.Repositories;
using System.Threading.Tasks;

namespace OrbitaChallengeGrupoA.Controllers
{
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;

        public StudentsController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var students = await _studentRepository.GetAllAsync();

            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var student = await _studentRepository.GetByIdAsync(id);

            if(student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateStudentInputModel studentInputModel)
        {
            var student = new Student(studentInputModel.Name, studentInputModel.Email, studentInputModel.AR, studentInputModel.CPF);

            await _studentRepository.AddAsync(student);
            await _studentRepository.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { Id = student.Id }, studentInputModel);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateStudentInputModel studentInputModel)
        {
            var student = await _studentRepository.GetByIdAsync(id);

            if(student == null)
            {
                return NotFound();
            }

            student.Update(studentInputModel.Name, studentInputModel.Email);

            await _studentRepository.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var student = await _studentRepository.GetByIdAsync(id);

            if (student == null)
            {
                return NotFound();
            }

            _studentRepository.Remove(student);

            await _studentRepository.SaveChangesAsync();

            return NoContent();
        }
    }
}
