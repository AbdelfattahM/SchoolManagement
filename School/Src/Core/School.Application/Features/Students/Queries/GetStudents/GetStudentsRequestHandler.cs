using AutoMapper;
using MediatR;
using School.Application.Dto;
using School.Domain.Entities;
using School.Domain.Specifications.Students;
using School.SharedKernel.Interfaces;

namespace School.Application.Features.Students.Queries.GetStudents
{
    public class GetStudentsRequestHandler
        : IRequestHandler<GetStudentsRequest, IReadOnlyList<StudentDto>>
    {
        private readonly IReadRepository<Student> studentRepository;
        private readonly IMapper mapper;

        public GetStudentsRequestHandler(IReadRepository<Student> studentRepository,
            IMapper mappper)
        {
            this.mapper = mappper;
            this.studentRepository = studentRepository;
        }

        public async Task<IReadOnlyList<StudentDto>> Handle(GetStudentsRequest request,
        CancellationToken cancellationToken)
        {
            var filter = new StudentFilter
            {
                IsTrackingEnabled = false,
                IsPagingEnabled = true,
                LoadChildren = true
            };
            var spec = new StudentByFilterSpec(filter);
            var allStudents = await studentRepository.ListAsync(spec, cancellationToken);
            return mapper.Map<IReadOnlyList<StudentDto>>(allStudents);
        }
    }
}
