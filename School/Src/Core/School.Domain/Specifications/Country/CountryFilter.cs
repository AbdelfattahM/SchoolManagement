namespace School.Domain.Specifications.Country;

public class CountryFilter : BaseFilter
{
    public int? Id { get; set; }
    public string Name { get; set; } = string.Empty;
}
