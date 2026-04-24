using EOkul.Application.Dtos.ResponseDtos;
using EOkul.Application.Dtos.TeacherDtos;
using EOkul.Application.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace EOkul.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly ITeacherService _teacherService;

        public TeachersController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTeachers()
        {
            var values = await _teacherService.GetAllTeachersAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTeacherById(int id)
        {
            var value = await _teacherService.GetTeacherByIdAsync(id);
            return Ok(value);
        }

        [HttpGet("with-classrooms-and-courses")]
        public async Task<IActionResult> GetAllTeachersWithClassroomsAndCourses()
        {
            var values = await _teacherService.GetAllTeachersWithClassroomsAndCourses();
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTeacher(CreateTeacherDto dto)
        {
            var result = await _teacherService.CreateTeacher(dto);
            if (!result.isSuccess)
            {
                if (result.ErrorCode == ErrorCode.ValidationError)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTeacher(UpdateTeacherDto dto)
        {
            var result = await _teacherService.UpdateTeacher(dto);
            if (!result.isSuccess)
            {
                if (result.ErrorCode == ErrorCode.ValidationError)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTeacher(int id)
        {
            await _teacherService.DeleteTeacher(id);
            return Ok("Öğretmen Başarıyla Silindi!");
        }
    }
}
