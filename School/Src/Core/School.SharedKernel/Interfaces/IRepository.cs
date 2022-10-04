using Ardalis.Specification;

namespace School.SharedKernel.Interfaces;

public interface IRepository<T> : IRepositoryBase<T> where T : class
{
}
