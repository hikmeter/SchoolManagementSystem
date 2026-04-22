using AutoMapper;
using EOkul.Application.Dtos.ClassroomDtos;
using EOkul.Application.Dtos.StudentDtos;
using EOkul.Application.Dtos.TeacherDtos;
using EOkul.Domain.Entities;

namespace EOkul.Application.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Student, CreateStudentDto>().ReverseMap();
            CreateMap<Student, UpdateStudentDto>().ReverseMap();
            CreateMap<Student, ResultStudentDto>().ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.Name + " " + src.Surname));
            CreateMap<Student, GetStudentByIdDto>().ReverseMap();
            CreateMap<Student, StudentWithClassroomsDto>().ForMember(dest => dest.ClassroomName, opt => opt.MapFrom(src => src.Classroom.Name)).ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.Name + " " + src.Surname));
            CreateMap<Student, GetStudentWithClassroomByIdDto>().ForMember(dest => dest.ClassroomName, opt => opt.MapFrom(src => src.Classroom.Name));

            CreateMap<Classroom, CreateClassroomDto>().ReverseMap();
            CreateMap<Classroom, UpdateClassroomDto>().ReverseMap();
            CreateMap<Classroom, ResultClassroomDto>().ForMember(dest => dest.TeacherName, opt => opt.MapFrom(src => src.Teacher.Name + " " + src.Teacher.Surname));
            CreateMap<Classroom, GetClassroomByIdDto>().ReverseMap();

            CreateMap<Teacher, CreateTeacherDto>().ReverseMap();
            CreateMap<Teacher, UpdateTeacherDto>().ReverseMap();
            CreateMap<Teacher, ResultTeacherDto>().ReverseMap();
            CreateMap<Teacher, GetTeacherByIdDto>().ReverseMap();
            CreateMap<Teacher, GetAllTeachersWithClassroomsAndCourses>().ForMember(dest => dest.ClassroomCount, opt => opt.MapFrom(src => src.Classrooms.Count())).ForMember(dest => dest.CourseCount, opt => opt.MapFrom(src => src.CourseAssignments.Distinct().Count()));
        }
    }
}
