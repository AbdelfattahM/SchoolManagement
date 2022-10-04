using Microsoft.AspNetCore.Components;
using School.Domain.Entities;
using School.UIBlazor.Contracts;

namespace School.UIBlazor.Pages;

public partial class StudentEdit
{
    [Inject]
    public IStudentsService StudentsService { get; set; }
    [Inject]
    public ICountryService CountryService { get; set; }

    [Parameter]
    public string StudentId { get; set; }

    public Student Student { get; set; } = new Student();
    public List<Country> CountryList { get; set; } = new List<Country>();

    protected override async Task OnInitializedAsync()
    {
        Student = await StudentsService.GetStudentDetails(int.Parse(StudentId));
        CountryList = (await CountryService.GetAllCountries()).ToList();
    }
}
