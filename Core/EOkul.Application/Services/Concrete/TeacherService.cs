using AutoMapper;
using EOkul.Application.Dtos.ResponseDtos;
using EOkul.Application.Dtos.TeacherDtos;
using EOkul.Application.Interfaces;
using EOkul.Application.Services.Abstract;
using EOkul.Domain.Entities;
using FluentValidation;

namespace EOkul.Application.Services.Concrete
{
    public class TeacherService : ITeacherService
    {
        private readonly IRepository<Teacher> _repository;
        private readonly ITeacherRepository _teacherRepository;
        private readonly IValidator<CreateTeacherDto> _createValidator;
        private readonly IValidator<UpdateTeacherDto> _updateValidator;
        private readonly IMapper _mapper;
        public TeacherService(IRepository<Teacher> repository, IMapper mapper, ITeacherRepository teacherRepository, IValidator<CreateTeacherDto> createValidator, IValidator<UpdateTeacherDto> updateValidator)
        {
            _repository = repository;
            _mapper = mapper;
            _teacherRepository = teacherRepository;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public async Task<ResponseDto<object>> CreateTeacher(CreateTeacherDto dto)
        {
            try
            {
                var validation = await _createValidator.ValidateAsync(dto);
                if (!validation.IsValid)
                {
                    return new ResponseDto<object> { isSuccess = false, Data = null, Message = string.Join(" | ", validation.Errors.Select(x => x.ErrorMessage)), ErrorCode = ErrorCode.ValidationError };
                }
                var value = _mapper.Map<Teacher>(dto);
                await _repository.CreateAsync(value);
                return new ResponseDto<object> { isSuccess = true, Data = value, Message = "Öğretmen başarıyla eklendi." };
            }
            catch (Exception ex)
            {
                return new ResponseDto<object> { isSuccess = false, Data = null, Message = ex.Message, ErrorCode = ErrorCode.Exception };
            }
        }

        public async Task DeleteTeacher(int id)
        {
            var value = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(value);
        }

        public async Task<List<ResultTeacherDto>> GetAllTeachersAsync()
        {
            var values = await _repository.GetAllAsync();
            return _mapper.Map<List<ResultTeacherDto>>(values);
        }

        public async Task<List<GetAllTeachersWithClassroomsAndCourses>> GetAllTeachersWithClassroomsAndCourses()
        {
            var values = await _teacherRepository.GetAllTeachersWithClassroomsAndCoursesCount();
            return _mapper.Map<List<GetAllTeachersWithClassroomsAndCourses>>(values);
        }

        public async Task<GetTeacherByIdDto> GetTeacherByIdAsync(int id)
        {
            var value = await _repository.GetByIdAsync(id);
            return _mapper.Map<GetTeacherByIdDto>(value);
        }

        public async Task<ResponseDto<object>> UpdateTeacher(UpdateTeacherDto dto)
        {
            try
            {
                var validation = await _updateValidator.ValidateAsync(dto);
                if (!validation.IsValid)
                {
                    return new ResponseDto<object> { isSuccess = false, Data = null, Message = String.Join(" | ", validation.Errors.Select(x => x.ErrorMessage)), ErrorCode = ErrorCode.ValidationError };
                }
                var value = await _repository.GetByIdAsync(dto.TeacherId);
                var newValue = _mapper.Map(dto, value);
                await _repository.UpdateAsync(newValue);
                return new ResponseDto<object> { isSuccess = true, Data = newValue, Message = "Öğretmen başarıyla güncellendi." };
            }
            catch (Exception ex)
            {
                return new ResponseDto<object> { isSuccess = false, Data = null, Message = ex.Message, ErrorCode = ErrorCode.Exception };
            }
        }
    }
}
