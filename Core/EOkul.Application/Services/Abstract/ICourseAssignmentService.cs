using EOkul.Application.Dtos.CourseAssignmentDtos;
using EOkul.Application.Dtos.ResponseDtos;

namespace EOkul.Application.Services.Abstract
{
    public interface ICourseAssignmentService
    {
        Task<List<ResultCourseAssignmentDto>> GetAllCourseAssignments();
        Task<ResultCourseAssignmentDto> GetCourseAssignmentById(int id);
        Task<ResponseDto<object>> CreateCourseAssignment(CreateCourseAssignmentDto dto);
        Task<ResponseDto<object>> UpdateCourseAssignment(UpdateCourseAssignmentDto dto);
        Task DeleteCourseAssignment(int id);
    }
}
