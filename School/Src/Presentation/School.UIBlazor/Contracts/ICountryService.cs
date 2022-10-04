using School.Domain.Entities;

namespace School.UIBlazor.Contracts;

public interface ICountryService
{
    Task<IEnumerable<Country>> GetAllCountries();
    Task<Country> GetCountryById(int contryId);
}
