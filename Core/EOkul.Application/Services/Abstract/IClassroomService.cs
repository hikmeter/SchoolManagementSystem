using EOkul.Application.Dtos.ClassroomDtos;
using EOkul.Application.Dtos.ResponseDtos;
using EOkul.Application.Dtos.StudentDtos;

namespace EOkul.Application.Services.Abstract
{
    public interface IClassroomService
    {
        Task<ResponseDto<List<ResultClassroomDto>>> GetAllClassrooms();
        Task<List<ResultStudentDto>> GetStudentsByClassroomId(int id);
        Task<GetClassroomByIdDto> GetClassroomById(int id);
        Task CreateClassroom(CreateClassroomDto dto);
        Task UpdateClassroom(UpdateClassroomDto dto);
        Task DeleteClassroom(int id);
    }
}
