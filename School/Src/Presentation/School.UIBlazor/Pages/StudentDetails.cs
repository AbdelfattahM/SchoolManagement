using Microsoft.AspNetCore.Components;
using School.Domain.Entities;
using School.UIBlazor.Contracts;
using School.UIBlazor.Services;

namespace School.UIBlazor.Pages
{
    public partial class StudentDetails
    {
        [Parameter]
        public string StudentId { get; set; }
        public Student Student { get; set; } = new Student();
        [Inject]
        public IStudentsService StudentsService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Student = await StudentsService.GetStudentDetails(int.Parse(StudentId));
        }

    }
}
