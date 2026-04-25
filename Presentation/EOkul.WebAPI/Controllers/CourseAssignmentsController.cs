using EOkul.Application.Dtos.CourseAssignmentDtos;
using EOkul.Application.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace EOkul.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseAssignmentsController : BaseController
    {
        private readonly ICourseAssignmentService _assignmentService;

        public CourseAssignmentsController(ICourseAssignmentService assignmentService)
        {
            _assignmentService = assignmentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCourseAssignments()
        {
            var values = await _assignmentService.GetAllCourseAssignments();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourseAssignmentById(int id)
        {
            var value = await _assignmentService.GetCourseAssignmentById(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCourseAssignment(CreateCourseAssignmentDto dto)
        {
            var result = await _assignmentService.CreateCourseAssignment(dto);
            return CreateResponse(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCourseAssignment(UpdateCourseAssignmentDto dto)
        {
            var result = await _assignmentService.UpdateCourseAssignment(dto);
            return CreateResponse(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCourseAssignment(int id)
        {
            await _assignmentService.DeleteCourseAssignment(id);
            return Ok("Ders Ataması Başarıyla Silindi!");
        }
    }
}
