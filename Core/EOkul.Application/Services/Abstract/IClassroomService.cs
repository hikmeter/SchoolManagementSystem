using EOkul.Application.Dtos.ClassroomDtos;

namespace EOkul.Application.Services.Abstract
{
    public interface IClassroomService
    {
        Task<List<ResultClassroomDto>> GetAllClassrooms();
        Task<GetClassroomByIdDto> GetClassroomById(int id);
        Task CreateClassroom(CreateClassroomDto dto);
        Task UpdateClassroom(UpdateClassroomDto dto);
        Task DeleteClassroom(int id);
    }
}
