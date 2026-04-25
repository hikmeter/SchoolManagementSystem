using EOkul.Application.Dtos.ResponseDtos;
using EOkul.Application.Dtos.StudentDtos;

namespace EOkul.Application.Services.Abstract
{
    public interface IStudentService
    {
        Task<List<ResultStudentDto>> GetAllStudentsAsync();
        Task<GetStudentByIdDto> GetStudentByIdAsync(int id);
        Task<GetStudentByIdDto> GetStudentByQuery(string query);
        Task<ResponseDto<object>> CreateStudent(CreateStudentDto dto);
        Task<ResponseDto<object>> UpdateStudent(UpdateStudentDto dto);
        Task DeleteStudent(int id);
        Task<List<StudentWithClassroomsDto>> GetAllStudentsWithClassroomsAsync();
        Task<GetStudentWithClassroomByIdDto> GetStudentWithClassroomNameByIdAsync(int id);
    }
}
