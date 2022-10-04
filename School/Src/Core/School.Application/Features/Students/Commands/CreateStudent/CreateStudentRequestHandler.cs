using AutoMapper;
using MediatR;
using School.Application.Dto;
using School.Domain.Entities;
using School.SharedKernel.Interfaces;

namespace School.Application.Features.Students.Commands.CreateStudent;

public class CreateStudentRequestHandler 
    : IRequestHandler<CreateStudentRequest, CreateStudentResponse>
{
    private readonly IRepository<Student> studentRepository;
    private readonly IMapper _mapper;

    public CreateStudentRequestHandler(IMapper mapper,
        IRepository<Student> studentRepository)
    {
        _mapper = mapper;
        this.studentRepository = studentRepository;
    }

    public async Task<CreateStudentResponse> Handle(CreateStudentRequest request,
            CancellationToken cancellationToken)
    {
        var createStudentResponse = new CreateStudentResponse();

        var validator = new CreateStudentRequetValidator();
        var validationResult = await validator.ValidateAsync(request);

        if (validationResult.Errors.Count > 0)
        {
            createStudentResponse.Success = false;
            createStudentResponse.ValidationErrors = new List<string>();
            foreach (var error in validationResult.Errors)
            {
                createStudentResponse.ValidationErrors.Add(error.ErrorMessage);
            }
        }

        if (createStudentResponse.Success)
        {
            var student = new Student() { Name = request.Name };
            var studentEntity = await studentRepository.AddAsync(student);
            createStudentResponse.Student = _mapper.Map<StudentDto>(studentEntity);
        }

        return createStudentResponse;
    }
}
