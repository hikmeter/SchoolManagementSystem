using AutoMapper;
using EOkul.Application.Dtos.CourseAssignmentDtos;
using EOkul.Application.Dtos.ResponseDtos;
using EOkul.Application.Interfaces;
using EOkul.Application.Services.Abstract;
using EOkul.Application.Validators.CourseAssignmentValidators;
using EOkul.Domain.Entities;

namespace EOkul.Application.Services.Concrete
{
    public class CourseAssignmentService : ICourseAssignmentService
    {
        private readonly IRepository<CourseAssignment> _repository;
        private readonly ICourseAssignmentRepository _assignmentRepository;
        private readonly CreateCourseAssignmentValidator _createValidator;
        private readonly UpdateCourseAssignmentValidator _updateValidator;
        private readonly IMapper _mapper;

        public CourseAssignmentService(IRepository<CourseAssignment> repository, CreateCourseAssignmentValidator createValidator, IMapper mapper, UpdateCourseAssignmentValidator updateValidator, ICourseAssignmentRepository assignmentRepository)
        {
            _repository = repository;
            _createValidator = createValidator;
            _mapper = mapper;
            _updateValidator = updateValidator;
            _assignmentRepository = assignmentRepository;
        }

        public async Task<ResponseDto<object>> CreateCourseAssignment(CreateCourseAssignmentDto dto)
        {
            try
            {
                var validation = await _createValidator.ValidateAsync(dto);
                if (!validation.IsValid)
                {
                    return new ResponseDto<object> { isSuccess = false, Data = null, Message = String.Join(" | ", validation.Errors.Select(x => x.ErrorMessage)), ErrorCode = ErrorCode.ValidationError };
                }
                var result = _mapper.Map<CourseAssignment>(dto);
                await _repository.CreateAsync(result);
                return new ResponseDto<object> { isSuccess = true, Data = result, Message = "Ders ataması başarıyla tamamlanmıştır." };
            }
            catch (Exception ex)
            {
                return new ResponseDto<object> { isSuccess = false, Data = null, Message = ex.Message, ErrorCode = ErrorCode.Exception };
            }
        }

        public async Task DeleteCourseAssignment(int id)
        {
            var value = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(value);
        }

        public async Task<List<ResultCourseAssignmentDto>> GetAllCourseAssignments()
        {
            var values = await _assignmentRepository.GetAllCourseAssignments();
            return _mapper.Map<List<ResultCourseAssignmentDto>>(values);
        }

        public async Task<ResultCourseAssignmentDto> GetCourseAssignmentById(int id)
        {
            var value = await _assignmentRepository.GetCourseAssignmentById(id);
            return _mapper.Map<ResultCourseAssignmentDto>(value);
        }

        public async Task<ResponseDto<object>> UpdateCourseAssignment(UpdateCourseAssignmentDto dto)
        {
            try
            {
                var validation = await _updateValidator.ValidateAsync(dto);
                if (!validation.IsValid)
                {
                    return new ResponseDto<object> { isSuccess = false, Data = null, Message = String.Join(" | ", validation.Errors.Select(x => x.ErrorMessage)), ErrorCode = ErrorCode.ValidationError };
                }
                var result = _mapper.Map<CourseAssignment>(dto);
                await _repository.UpdateAsync(result);
                return new ResponseDto<object> { isSuccess = true, Data = result, Message = "Ders ataması başarıyla güncellenmiştir." };
            }
            catch (Exception ex)
            {
                return new ResponseDto<object> { isSuccess = false, Data = null, Message = ex.Message, ErrorCode = ErrorCode.Exception };
            }
        }
    }
}
