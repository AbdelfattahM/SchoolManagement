using School.Domain.Entities;
using School.UIBlazor.Contracts;
using System.Text;
using System.Text.Json;

namespace School.UIBlazor.Services;

public class StudentsService : IStudentsService
{
    private readonly HttpClient _httpClient;

    public StudentsService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<Student>> GetAllStudents()
    {
        return await JsonSerializer.DeserializeAsync<IEnumerable<Student>>
                    (await _httpClient.GetStreamAsync($"api/student/all"), 
                        new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
    }

    public async Task<Student> GetStudentDetails(int studentId)
    {
        return await JsonSerializer.DeserializeAsync<Student>
                (await _httpClient.GetStreamAsync($"api/student/{studentId}"), 
                    new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
    }

    public async Task<Student> AddStudent(Student student)
    {
        var studentJson =
            new StringContent(JsonSerializer.Serialize(student), 
                                Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync("api/student", studentJson);

        if (response.IsSuccessStatusCode)
        {
            return await JsonSerializer
                .DeserializeAsync<Student>(await response.Content.ReadAsStreamAsync());
        }

        return null;
    }

    public async Task UpdateStudent(Student student)
    {
        var studentJson =
            new StringContent(JsonSerializer.Serialize(student), 
                                Encoding.UTF8, "application/json");

        await _httpClient.PutAsync("api/student", studentJson);
    }

    public async Task DeleteStudent(int studentId)
    {
        await _httpClient.DeleteAsync($"api/student/{studentId}");
    }
}
