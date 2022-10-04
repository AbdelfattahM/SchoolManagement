namespace School.Domain.Specifications.Students;

public class StudentFilter : BaseFilter
{
    public int? Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public int? CountryId { get; set; }
    public DateTime? DateOfBirth { get; set; }
}
