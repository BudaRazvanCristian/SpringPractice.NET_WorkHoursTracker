using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace WorkHoursTracker.ConsoleClient;

public class ApiClient
{
    private readonly HttpClient _http;
    private readonly string _baseUrl = "http://localhost:5173/api/work/";

    public ApiClient()
    {
        _http = new HttpClient();
    }

    public async Task<string> StartWorkAsync(string username)
    {
        var content = CreateJsonBody(username);
        var res = await _http.PostAsync(_baseUrl + "start", content);
        return await res.Content.ReadAsStringAsync();
    }

    public async Task<string> StopWorkAsync(string username)
    {
        var content = CreateJsonBody(username);
        var res = await _http.PostAsync(_baseUrl + "stop", content);
        return await res.Content.ReadAsStringAsync();
    }

    public async Task<string> GetTodayAsync(string username)
    {
        return await _http.GetStringAsync(_baseUrl + $"today?username={username}");
    }

    public async Task<string> GetWeekAsync(string username)
    {
        return await _http.GetStringAsync(_baseUrl + $"week?username={username}");
    }

    public async Task<string> GetLogsAsync(string username)
    {
        return await _http.GetStringAsync(_baseUrl + $"logs?username={username}");
    }

    private StringContent CreateJsonBody(string username)
    {
        var body = JsonSerializer.Serialize(new { username });
        return new StringContent(body, Encoding.UTF8, "application/json");
    }
}
