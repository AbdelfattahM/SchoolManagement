using School.Domain.Entities;
using School.UIBlazor.Contracts;
using System.Text;
using System.Text.Json;

namespace School.UIBlazor.Services;

public class CourseService : ICourseService
{
    private readonly HttpClient _httpClient;

    public CourseService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<Course> AddCourse(Course course)
    {
        var courseJson =
            new StringContent(JsonSerializer.Serialize(course),
                                Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync("api/course", courseJson);

        if (response.IsSuccessStatusCode)
        {
            return await JsonSerializer
                .DeserializeAsync<Course>(await response.Content.ReadAsStreamAsync());
        }

        return null;
    }

    public async Task DeleteCourse(int courseId)
    {
        await _httpClient.DeleteAsync($"api/course/{courseId}");
    }

    public async Task<IEnumerable<Course>> GetAllCourses()
    {
        return await JsonSerializer.DeserializeAsync<IEnumerable<Course>>
                    (await _httpClient.GetStreamAsync($"api/course/all"),
                        new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
    }

    public async Task<Course> GetCourseDetails(int courseId)
    {
        return await JsonSerializer.DeserializeAsync<Course>
                (await _httpClient.GetStreamAsync($"api/course/{courseId}"),
                    new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
    }

    public async Task UpdateCourse(Course course)
    {
        var courseJson =
           new StringContent(JsonSerializer.Serialize(course),
                               Encoding.UTF8, "application/json");

        await _httpClient.PutAsync("api/course", courseJson);
    }
}
