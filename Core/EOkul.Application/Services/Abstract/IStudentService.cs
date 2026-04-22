using EOkul.Application.Dtos.StudentDtos;

namespace EOkul.Application.Services.Abstract
{
    public interface IStudentService
    {
        Task<List<ResultStudentDto>> GetAllStudentsAsync();
        Task<GetStudentByIdDto> GetStudentByIdAsync(int id);
        Task CreateStudent(CreateStudentDto dto);
        Task UpdateStudent(UpdateStudentDto dto);
        Task DeleteStudent(int id);
        Task<List<StudentWithClassroomsDto>> GetAllStudentsWithClassroomsAsync();
        Task<GetStudentWithClassroomByIdDto> GetStudentWithClassroomNameByIdAsync(int id);
    }
}
