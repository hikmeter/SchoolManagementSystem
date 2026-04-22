using AutoMapper;
using EOkul.Application.Dtos.ClassroomDtos;
using EOkul.Application.Interfaces;
using EOkul.Application.Services.Abstract;
using EOkul.Domain.Entities;

namespace EOkul.Application.Services.Concrete
{
    public class ClassroomService : IClassroomService
    {
        private readonly IRepository<Classroom> _repository;
        private readonly IMapper _mapper;

        public ClassroomService(IMapper mapper, IRepository<Classroom> repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task CreateClassroom(CreateClassroomDto dto)
        {
            var value = _mapper.Map<Classroom>(dto);
            await _repository.CreateAsync(value);
        }

        public async Task DeleteClassroom(int id)
        {
            var value = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(value);
        }

        public async Task<List<ResultClassroomDto>> GetAllClassrooms()
        {
            var values = await _repository.GetAllAsync();
            return _mapper.Map<List<ResultClassroomDto>>(values);
        }

        public async Task<GetClassroomByIdDto> GetClassroomById(int id)
        {
            var value = await _repository.GetByIdAsync(id);
            return _mapper.Map<GetClassroomByIdDto>(value);

        }

        public async Task UpdateClassroom(UpdateClassroomDto dto)
        {
            var value = _mapper.Map<Classroom>(dto);
            await _repository.UpdateAsync(value);
        }
    }
}
