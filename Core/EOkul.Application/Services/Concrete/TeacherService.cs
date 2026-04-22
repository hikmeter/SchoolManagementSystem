using AutoMapper;
using EOkul.Application.Dtos.TeacherDtos;
using EOkul.Application.Interfaces;
using EOkul.Application.Services.Abstract;
using EOkul.Domain.Entities;

namespace EOkul.Application.Services.Concrete
{
    public class TeacherService : ITeacherService
    {
        private readonly IRepository<Teacher> _repository;
        private readonly ITeacherRepository _teacherRepository;
        private readonly IMapper _mapper;
        public TeacherService(IRepository<Teacher> repository, IMapper mapper, ITeacherRepository teacherRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _teacherRepository = teacherRepository;
        }

        public async Task CreateTeacher(CreateTeacherDto dto)
        {
            var value = _mapper.Map<Teacher>(dto);
            await _repository.CreateAsync(value);
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

        public async Task UpdateTeacher(UpdateTeacherDto dto)
        {
            var value = await _repository.GetByIdAsync(dto.TeacherId);
            var newValue = _mapper.Map(dto, value);
            await _repository.UpdateAsync(newValue);
        }
    }
}
