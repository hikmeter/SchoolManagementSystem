using AutoMapper;
using EOkul.Application.Dtos.StudentDtos;
using EOkul.Application.Interfaces;
using EOkul.Application.Services.Abstract;
using EOkul.Domain.Entities;

namespace EOkul.Application.Services.Concrete
{
    public class StudentService : IStudentService
    {
        private readonly IRepository<Student> _repository;
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public StudentService(IRepository<Student> repository, IMapper mapper, IStudentRepository studentRepository)
        {
            _repository = repository;
            _mapper = mapper;
            this._studentRepository = studentRepository;
        }

        public async Task CreateStudent(CreateStudentDto dto)
        {
            var value = _mapper.Map<Student>(dto);
            await _repository.CreateAsync(value);
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

        public async Task<GetStudentWithClassroomByIdDto> GetStudentWithClassroomNameByIdAsync(int id)
        {
            var value = await _studentRepository.GetStudentWithClassroomName(id);
            return _mapper.Map<GetStudentWithClassroomByIdDto>(value);
        }

        public async Task UpdateStudent(UpdateStudentDto dto)
        {
            var value = _mapper.Map<Student>(dto);
            await _repository.UpdateAsync(value);
        }
    }
}
