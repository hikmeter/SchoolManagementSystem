using EOkul.Application.Dtos.CourseDtos;
using EOkul.Application.Dtos.ResponseDtos;
using EOkul.Application.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace EOkul.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CoursesController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCourses()
        {
            var values = await _courseService.GetAllCourses();
            return Ok(values);
        }

        [HttpGet("active-courses")]
        public async Task<IActionResult> GetAllActiveCourses()
        {
            var values = await _courseService.GetAllActiveCourses();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourseById(int id)
        {
            var value = await _courseService.GetCourseById(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCourse(CreateCourseDto dto)
        {
            var result = await _courseService.CreateCourse(dto);
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
        public async Task<IActionResult> UpdateCourse(UpdateCourseDto dto)
        {
            var result = await _courseService.UpdateCourse(dto);
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            await _courseService.DeleteCourse(id);
            return Ok("Ders Başarıyla Silindi!");
        }
    }
}
