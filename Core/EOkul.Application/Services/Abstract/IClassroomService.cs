using EOkul.Application.Dtos.ClassroomDtos;
using EOkul.Application.Dtos.ResponseDtos;

namespace EOkul.Application.Services.Abstract
{
    public interface IClassroomService
    {
        Task<ResponseDto<List<ResultClassroomDto>>> GetAllClassrooms();
        Task<GetClassroomByIdDto> GetClassroomById(int id);
        Task CreateClassroom(CreateClassroomDto dto);
        Task UpdateClassroom(UpdateClassroomDto dto);
        Task DeleteClassroom(int id);
    }
}
