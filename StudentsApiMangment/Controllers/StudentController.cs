using Microsoft.AspNetCore.Mvc;
using StudentsApiMangment.Interface;
using StudentsApiMangment.Models;

namespace StudentsApiMangment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudent _student;

        public StudentController(IStudent student)
        {
            _student = student; 
        }

        /// <summary>
        /// Retrieves all students.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        {
            var students = await _student.GetAllStudentsAsync();
            return Ok(students);
        }

        /// <summary>
        /// Retrieves a student by their ID.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudent(int id)
        {
            var student = await _student.GetStudentByIdAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        /// <summary>
        /// Adds a new student.
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<Student>> PostStudent(Student student)
        {
            await _student.AddStudentAsync(student);
            return CreatedAtAction(nameof(GetStudent), new { id = student.Id }, student);
        }

        /// <summary>
        /// Updates an existing student.
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudent(int id, Student student)
        {
            if (id != student.Id)
            {
                return BadRequest();
            }
            await _student.UpdateStudentAsync(student);
            return NoContent();
        }

        /// <summary>
        /// Deletes a student by their ID.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            await _student.DeleteStudentAsync(id);
            return NoContent();
        }
    }
}
