using AutoMapper;
using School.Application.Dto;
using School.Application.Features.Students.Commands.UpdateStudent;
using School.Domain.Entities;

namespace School.Application.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Student,CountryStudent>();
        CreateMap<Country, CountryDto>();
        
        //CreateMap<Country, UpdateCountryRequest>().ReverseMap();

        // Students
        CreateMap<Student,StudentDto>();
        CreateMap<UpdateStudentRequest, StudentDto>();

        // Courses
        CreateMap<Course,CourseDto>();
        CreateMap<Course,StudentCourse>();
    }
}
