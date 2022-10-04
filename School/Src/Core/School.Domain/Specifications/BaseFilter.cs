namespace School.Domain.Specifications;

public class BaseFilter
{
    public bool LoadChildren { get; set; } = true;
    public bool IsPagingEnabled { get; set; } = false;
    public bool IsTrackingEnabled { get; set; } = true;

    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}
