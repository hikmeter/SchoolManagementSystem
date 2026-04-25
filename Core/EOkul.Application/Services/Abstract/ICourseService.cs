using EOkul.Application.Dtos.CourseDtos;
using EOkul.Application.Dtos.ResponseDtos;

namespace EOkul.Application.Services.Abstract
{
    public interface ICourseService
    {
        Task<List<ResultCourseDto>> GetAllCourses();
        Task<List<ResultCourseDto>> GetAllActiveCourses();
        Task<GetCourseByIdDto> GetCourseById(int id);
        Task<ResponseDto<object>> CreateCourse(CreateCourseDto dto);
        Task<ResponseDto<object>> UpdateCourse(UpdateCourseDto dto);
        Task DeleteCourse(int id);
    }
}