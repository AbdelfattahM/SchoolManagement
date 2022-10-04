using Microsoft.AspNetCore.Components;
using School.Domain.Entities;
using School.UIBlazor.Contracts;

namespace School.UIBlazor.Pages;

public partial class StudentsList
{
    public IEnumerable<Student> Students { get; set; }

    [Inject]
    public IStudentsService StudentService { set; get; }

    protected override async Task OnInitializedAsync()
    {
        Students = (await StudentService.GetAllStudents()).ToList();
    }
}
