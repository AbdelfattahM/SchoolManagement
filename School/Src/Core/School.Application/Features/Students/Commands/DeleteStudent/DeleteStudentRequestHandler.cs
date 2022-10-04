using AutoMapper;
using MediatR;
using School.Application.Exceptions;
using School.Domain.Entities;
using School.SharedKernel.Interfaces;

namespace School.Application.Features.Students.Commands.DeleteStudent;

public class DeleteStudentRequestHandler : IRequestHandler<DeleteStudentRequest>
{
    private readonly IRepository<Student> studentRepository;
    private readonly IMapper mapper;

    public DeleteStudentRequestHandler(IMapper mapper, IRepository<Student> studentRepository)
    {
        this.mapper = mapper;
        this.studentRepository = studentRepository;
    }

    public async Task<Unit> Handle(DeleteStudentRequest request,
        CancellationToken cancellationToken)
    {
        var countryToDelete = await studentRepository.GetByIdAsync(request.Id);

        if (countryToDelete == null)
        {
            throw new NotFoundException(nameof(Student), request.Id);
        }

        await studentRepository.DeleteAsync(countryToDelete);

        return Unit.Value;
    }
}
