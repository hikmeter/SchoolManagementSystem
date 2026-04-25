using AutoMapper;
using EOkul.Application.Dtos.ResponseDtos;
using EOkul.Application.Dtos.StudentDtos;
using EOkul.Application.Interfaces;
using EOkul.Application.Services.Abstract;
using EOkul.Domain.Entities;
using FluentValidation;

namespace EOkul.Application.Services.Concrete
{
    public class StudentService : IStudentService
    {
        private readonly IRepository<Student> _repository;
        private readonly IStudentRepository _studentRepository;
        private readonly IValidator<CreateStudentDto> _createValidator;
        private readonly IValidator<UpdateStudentDto> _updateValidator;
        private readonly IMapper _mapper;

        public StudentService(IRepository<Student> repository, IMapper mapper, IStudentRepository studentRepository, IValidator<CreateStudentDto> createValidator, IValidator<UpdateStudentDto> updateValidator)
        {
            _repository = repository;
            _mapper = mapper;
            _studentRepository = studentRepository;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public async Task<ResponseDto<object>> CreateStudent(CreateStudentDto dto)
        {
            try
            {
                var validation = await _createValidator.ValidateAsync(dto);

                if (!validation.IsValid)
                {
                    return new ResponseDto<object>
                    {
                        isSuccess = false,
                        Data = null,
                        Message = string.Join(" | ", validation.Errors.Select(x => x.ErrorMessage)),
                        ErrorCode = ErrorCode.ValidationError
                    };
                }

                var student = _mapper.Map<Student>(dto);

                await _repository.CreateAsync(student);

                return new ResponseDto<object>
                {
                    isSuccess = true,
                    Data = student,
                    Message = "Öğrenci başarıyla eklendi."
                };
            }
            catch (Exception ex)
            {
                return new ResponseDto<object>
                {
                    isSuccess = false,
                    Data = null,
                    Message = ex.Message,
                    ErrorCode = ErrorCode.Exception
                };
            }
        }

        public async Task DeleteStudent(int id)
        {
            var value = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(value);
        }

        public async Task<List<ResultStudentDto>> GetAllStudentsAsync()
        {
            var values = await _repository.GetAllAsync();
            return _mapper.Map<List<ResultStudentDto>>(values);
        }

        public async Task<List<StudentWithClassroomsDto>> GetAllStudentsWithClassroomsAsync()
        {
            var values = await _studentRepository.GetAllStudentsWithClassroomsAsync();
            return _mapper.Map<List<StudentWithClassroomsDto>>(values);
        }

        public async Task<GetStudentByIdDto> GetStudentByIdAsync(int id)
        {
            var value = await _repository.GetByIdAsync(id);
            return _mapper.Map<GetStudentByIdDto>(value);
        }

        public async Task<GetStudentByIdDto> GetStudentByQuery(string query)
        {
            var value = await _studentRepository.GetStudentByQueryAsync(query);
            return _mapper.Map<GetStudentByIdDto>(value);
        }

        public async Task<GetStudentWithClassroomByIdDto> GetStudentWithClassroomNameByIdAsync(int id)
        {
            var value = await _studentRepository.GetStudentWithClassroomNameAsync(id);
            return _mapper.Map<GetStudentWithClassroomByIdDto>(value);
        }

        public async Task<ResponseDto<object>> UpdateStudent(UpdateStudentDto dto)
        {
            try
            {
                var validation = await _updateValidator.ValidateAsync(dto);
                if (!validation.IsValid)
                {
                    return new ResponseDto<object> { isSuccess = false, Data = null, Message = string.Join(" | ", validation.Errors.Select(x => x.ErrorMessage)), ErrorCode = ErrorCode.ValidationError };
                }
                var value = _mapper.Map<Student>(dto);
                await _repository.UpdateAsync(value);
                return new ResponseDto<object> { isSuccess = true, Data = value, Message = "Öğrenci başarıyla güncellendi." };
            }
            catch (Exception ex)
            {
                return new ResponseDto<object> { isSuccess = false, Data = null, Message = ex.Message, ErrorCode = ErrorCode.Exception };
            }
        }
    }
}
