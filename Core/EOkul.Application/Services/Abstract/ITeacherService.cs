using EOkul.Application.Dtos.TeacherDtos;

namespace EOkul.Application.Services.Abstract
{
    public interface ITeacherService
    {
        Task<List<ResultTeacherDto>> GetAllTeachersAsync();
        Task<GetTeacherByIdDto> GetTeacherByIdAsync(int id);
        Task CreateTeacher(CreateTeacherDto dto);
        Task UpdateTeacher(UpdateTeacherDto dto);
        Task DeleteTeacher(int id);
        Task<List<GetAllTeachersWithClassroomsAndCourses>> GetAllTeachersWithClassroomsAndCourses();
    }
}
