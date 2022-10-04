using AutoMapper;
using MediatR;
using School.Application.Exceptions;
using School.Domain.Entities;
using School.SharedKernel.Interfaces;

namespace School.Application.Features.Students.Commands.UpdateStudent;

public class UpdateStudentRequestHandler : IRequestHandler<UpdateStudentRequest>
{
    private readonly IRepository<Student> studentRepository;
    private readonly IMapper _mapper;

    public UpdateStudentRequestHandler(IMapper mapper,
        IRepository<Student> studentRepository)
    {
        _mapper = mapper;
        this.studentRepository = studentRepository;
    }

    public async Task<Unit> Handle(UpdateStudentRequest request,
        CancellationToken cancellationToken)
    {
        var studentToUpdate = await studentRepository.GetByIdAsync(request.Id);

        if (studentToUpdate == null)
        {
            throw new NotFoundException(nameof(Student), request.Id);
        }

        var validator = new UpdateStudentRequestValidator();
        var validationResult = await validator.ValidateAsync(request);

        if (validationResult.Errors.Count > 0)
            throw new ValidationException(validationResult);

        _mapper.Map(request, studentToUpdate, typeof(UpdateStudentRequest),typeof(Student));

        await studentRepository.UpdateAsync(studentToUpdate);

        return Unit.Value;
    }
}
