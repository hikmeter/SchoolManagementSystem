using AutoMapper;
using EOkul.Application.Dtos.CourseDtos;
using EOkul.Application.Dtos.ResponseDtos;
using EOkul.Application.Interfaces;
using EOkul.Application.Services.Abstract;
using EOkul.Domain.Entities;
using FluentValidation;

namespace EOkul.Application.Services.Concrete
{
    public class CourseService : ICourseService
    {
        private readonly IRepository<Course> _repository;
        private readonly ICourseRepository _courseRepository;
        private readonly IValidator<CreateCourseDto> _createValidator;
        private readonly IValidator<UpdateCourseDto> _updateValidator;
        private readonly IMapper _mapper;
        public CourseService(IRepository<Course> repository, IMapper mapper, IValidator<CreateCourseDto> createValidator, IValidator<UpdateCourseDto> updateValidator, ICourseRepository courseRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
            _courseRepository = courseRepository;
        }

        public async Task<ResponseDto<object>> CreateCourse(CreateCourseDto dto)
        {
            try
            {
                var validation = await _createValidator.ValidateAsync(dto);
                if (!validation.IsValid)
                {
                    return new ResponseDto<object> { isSuccess = false, Data = null, Message = String.Join(" | ", validation.Errors.Select(x => x.ErrorMessage)), ErrorCode = ErrorCode.ValidationError };
                }
                var course = _mapper.Map<Course>(dto);
                await _repository.CreateAsync(course);
                return new ResponseDto<object> { isSuccess = true, Data = course, Message = "Ders başarıyla oluşturuldu!" };
            }
            catch (Exception ex)
            {
                return new ResponseDto<object> { isSuccess = false, Data = null, Message = ex.Message, ErrorCode = ErrorCode.Exception };
            }
        }

        public async Task DeleteCourse(int id)
        {
            var value = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(value);
        }

        public async Task<List<ResultCourseDto>> GetAllActiveCourses()
        {
            var values = await _courseRepository.GetAllActiveCoursesAsync();
            return _mapper.Map<List<ResultCourseDto>>(values);
        }

        public async Task<List<ResultCourseDto>> GetAllCourses()
        {
            var values = await _repository.GetAllAsync();
            return _mapper.Map<List<ResultCourseDto>>(values);
        }

        public async Task<GetCourseByIdDto> GetCourseById(int id)
        {
            var value = await _repository.GetByIdAsync(id);
            return _mapper.Map<GetCourseByIdDto>(value);
        }

        public async Task<ResponseDto<object>> UpdateCourse(UpdateCourseDto dto)
        {
            try
            {
                var validation = await _updateValidator.ValidateAsync(dto);
                if (!validation.IsValid)
                {
                    return new ResponseDto<object> { isSuccess = false, Data = null, Message = String.Join(" | ", validation.Errors.Select(x => x.ErrorMessage)), ErrorCode = ErrorCode.ValidationError };
                }
                var value = _mapper.Map<Course>(dto);
                await _repository.UpdateAsync(value);
                return new ResponseDto<object> { isSuccess = true, Data = value, Message = "Ders başarıyla güncellendi." };
            }
            catch (Exception ex)
            {
                return new ResponseDto<object> { isSuccess = false, Data = null, Message = ex.Message, ErrorCode = ErrorCode.Exception };
            }
        }
    }
}
