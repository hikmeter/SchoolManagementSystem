using AutoMapper;
using EOkul.Application.Dtos.ClassroomDtos;
using EOkul.Application.Dtos.ResponseDtos;
using EOkul.Application.Dtos.StudentDtos;
using EOkul.Application.Interfaces;
using EOkul.Application.Services.Abstract;
using EOkul.Domain.Entities;

namespace EOkul.Application.Services.Concrete
{
    public class ClassroomService : IClassroomService
    {
        private readonly IRepository<Classroom> _repository;
        private readonly IClassroomRepository _classroomRepository;
        private readonly IMapper _mapper;

        public ClassroomService(IMapper mapper, IRepository<Classroom> repository, IClassroomRepository classroomRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _classroomRepository = classroomRepository;
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

        public async Task<ResponseDto<List<ResultClassroomDto>>> GetAllClassrooms()
        {
            try
            {
                var values = await _repository.GetAllAsync();
                if (values.Count == 0)
                {
                    return new ResponseDto<List<ResultClassroomDto>> { isSuccess = false, Message = "Sınıf Bulunamadı!", ErrorCode = ErrorCode.NotFound };
                }
                var result = _mapper.Map<List<ResultClassroomDto>>(values);
                return new ResponseDto<List<ResultClassroomDto>> { isSuccess = true, Data = result };
            }
            catch (Exception ex)
            {
                return new ResponseDto<List<ResultClassroomDto>> { isSuccess = false, Message = ex.Message, ErrorCode = ErrorCode.Exception };
            }
        }

        public async Task<GetClassroomByIdDto> GetClassroomById(int id)
        {
            var value = await _repository.GetByIdAsync(id);
            return _mapper.Map<GetClassroomByIdDto>(value);

        }

        public async Task<List<ResultStudentDto>> GetStudentsByClassroomId(int id)
        {
            var values = await _classroomRepository.GetStudentsByClassroomIdAsync(id);
            return _mapper.Map<List<ResultStudentDto>>(values);
        }

        public async Task UpdateClassroom(UpdateClassroomDto dto)
        {
            var value = _mapper.Map<Classroom>(dto);
            await _repository.UpdateAsync(value);
        }
    }
}
