using AutoMapper;
using MediatR;
using School.Application.Dto;
using School.Application.Features.Students.Commands.CreateStudent;
using School.Domain.Entities;
using School.SharedKernel.Interfaces;

namespace School.Application.Features.Courses.Commands.CreateCourse
{
    public class CreateCourseRequestHandler 
        : IRequestHandler<CreateCourseRequest, CreateCourseResponse>
    {
        private readonly IRepository<Student> courseRepository;
        private readonly IMapper _mapper;

        public CreateCourseRequestHandler(IMapper mapper,
            IRepository<Student> studentRepository)
        {
            _mapper = mapper;
            this.courseRepository = studentRepository;
        }

        public async Task<CreateCourseResponse> Handle(CreateCourseRequest request,
                CancellationToken cancellationToken)
        {
            var createCourseResponse = new CreateCourseResponse();

            var validator = new CreateCourseRequetValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                createCourseResponse.Success = false;
                createCourseResponse.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    createCourseResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }

            if (createCourseResponse.Success)
            {
                var course = new Student() { Name = request.Name };
                var courseEntity = await courseRepository.AddAsync(course);
                createCourseResponse.Course = _mapper.Map<CourseDto>(courseEntity);
            }

            return createCourseResponse;
        }
    }
}
