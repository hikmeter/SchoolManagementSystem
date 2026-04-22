using EOkul.Application.Dtos.ClassroomDtos;
using EOkul.Application.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace EOkul.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClasroomsController : ControllerBase
    {
        private readonly IClassroomService _classroomService;

        public ClasroomsController(IClassroomService classroomService)
        {
            _classroomService = classroomService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllClassrooms()
        {
            var values = await _classroomService.GetAllClassrooms();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetClassroomById(int id)
        {
            var value = await _classroomService.GetClassroomById(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateClassroom(CreateClassroomDto dto)
        {
            await _classroomService.CreateClassroom(dto);
            return Ok("Sınıf Başarıyla Oluşturuldu!");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateClassroom(UpdateClassroomDto dto)
        {
            await _classroomService.UpdateClassroom(dto);
            return Ok("Sınıf Başarıyla Güncellendi!");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteClassroom(int id)
        {
            await _classroomService.DeleteClassroom(id);
            return Ok("Sınıf Başarıyla Silindi!");
        }
    }
}
