using School.Domain.Entities;

namespace School.Persistence;

public class DataSeedFactory
{
	private static readonly Country[] _Countries = new Country[]{
		new Country { Id = 1, Name = "Egypt" },
		new Country { Id = 2, Name = "Omman" },
		new Country { Id = 3, Name = "Saudi Arabia"},
		new Country { Id = 4, Name = "Libya"}
	};
	private static readonly Course[] _Courses = new Course[] {
		new Course { Id = 1, Name = "Calculas"},
		new Course { Id = 2, Name = "Linear Algebra"},
		new Course { Id = 3, Name = "Algorithms"},
		new Course { Id = 4, Name = "Quantam Mechanics"}
	};
	private static readonly Student[] _Students= new Student[]{
		new Student { Id = 1, Name = "Ahmed Ali", DateOfBirth = new DateTime(2002,09,18), ImageUrl= "", CountryId= 1},
		new Student { Id = 2, Name = "Hend Salem", DateOfBirth = new DateTime(2000,02,13), ImageUrl = "", CountryId = 1 },
		new Student { Id = 3, Name = "Eyad Mohammed", DateOfBirth = new DateTime(1994,03,20), ImageUrl = "", CountryId = 2 },
		new Student { Id = 4, Name = "Lena Mustafa", DateOfBirth = new DateTime(1990,03,20), ImageUrl = "", CountryId = 3 }
	};
	private static readonly Enrollment[] _Enrollments = new Enrollment[]
	{
		new Enrollment { Id = 1, CourseId = 1,StudentId=1 },
		new Enrollment { Id = 2, CourseId = 2, StudentId = 1 },
		new Enrollment { Id = 3, CourseId = 3, StudentId = 1 },
		new Enrollment { Id = 4, CourseId = 1, StudentId = 2 },
		new Enrollment { Id = 5, CourseId = 3, StudentId = 2 },
		new Enrollment { Id = 6, CourseId = 2, StudentId = 3 },
		new Enrollment { Id = 7, CourseId = 3, StudentId = 3 }
	};

	public static IReadOnlyList<Student> Students => _Students;
	public static IReadOnlyList<Course> Courses => _Courses;
	public static IReadOnlyList<Country> Countries => _Countries;
	public static IReadOnlyList<Enrollment> Enrollments => _Enrollments;

	public static void Seed(SchoolContext context)
	{
		using var transaction = context.Database.BeginTransaction();
		try
		{
			context.Database.EnsureCreated();
			if (context.Students.Any())
			{
				return;
			}

			context.Countries.AddRange(_Countries);
			context.SaveChanges();

			context.Courses.AddRange(_Courses);
			context.SaveChanges();

			context.Students.AddRange(_Students);
			context.SaveChanges();

			context.Enrollments.AddRange(_Enrollments);
			context.SaveChanges();

			transaction.Commit();
		}
		catch (Exception)
		{
			// TODO: Log exception.
			transaction.Rollback();
			throw;
		}
	}
}
