using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using AutoLottoMaui.Models;

namespace AutoLottoMaui.Services;

public class HttpService
{
    private readonly HttpClient _httpClient;
    private const string megaMilUrl = "https://data.ny.gov/resource/d6yy-54nr.json";

    public HttpService()
    {
        _httpClient = new HttpClient();
    }

    public async Task<Drawing> FetchDataAsync()
    {
        try
        {
            var response = await _httpClient.GetAsync(megaMilUrl);
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Drawing>(json);
        }
        catch (Exception ex)
        {
            // Handle exceptions
            Console.WriteLine($"An error occurred: {ex.Message}");
            return null;
        }
    }
}