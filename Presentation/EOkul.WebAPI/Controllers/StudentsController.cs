using EOkul.Application.Dtos.StudentDtos;
using EOkul.Application.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace EOkul.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : BaseController
    {
        private readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            var values = await _studentService.GetAllStudentsAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            var value = await _studentService.GetStudentByIdAsync(id);
            return Ok(value);
        }

        [HttpGet("{query}fast-search")]
        public async Task<IActionResult> GetStudentByQuery(string query)
        {
            var value = await _studentService.GetStudentByQuery(query);
            return Ok(value);
        }

        [HttpGet("with-classrooms")]
        public async Task<IActionResult> GetStudentsWithClassrooms()
        {
            var values = await _studentService.GetAllStudentsWithClassroomsAsync();
            return Ok(values);
        }

        [HttpGet("{id}with-classroom-by-id")]
        public async Task<IActionResult> GetStudentWithClassroomNameById(int id)
        {
            var value = await _studentService.GetStudentWithClassroomNameByIdAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudent(CreateStudentDto dto)
        {
            var result = await _studentService.CreateStudent(dto);
            return CreateResponse(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateStudent(UpdateStudentDto dto)
        {
            var result = await _studentService.UpdateStudent(dto);
            return CreateResponse(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            await _studentService.DeleteStudent(id);
            return Ok("Öğrenci Başarıyla Silindi!");
        }
    }
}
