using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using School.Application.Contracts.Persistence;
using School.Persistence.Repositories;
using School.SharedKernel.Interfaces;

namespace School.Persistence;

public static class PersistanceServiceRegistration
{
    public static IServiceCollection AddPersistanceServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<SchoolContext>(options =>
           options.UseSqlite(configuration.GetConnectionString("SchoolSQLiteConnection"))
           );
        services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
        services.AddScoped(typeof(IReadRepository<>), typeof(BaseRepository<>));
        
        services.AddScoped<ICountryRepository, CountryRepository>();
        services.AddScoped<ICourseRepository, CourseRepository>();
        services.AddScoped<IEnrollmentRepository, EnrollmentRepository>();
        services.AddScoped<IStudentRepository, StudentRepository>();

        #region Seed Database
        using var scope = services.BuildServiceProvider().CreateScope();
        var serviceProvider = scope.ServiceProvider;
        var context = serviceProvider.GetRequiredService<SchoolContext>();
        DataSeedFactory.Seed(context); 
        #endregion

        return services;
    }
}
