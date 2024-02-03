using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;
using AutoLottoMaui.Models;

namespace AutoLottoMaui.Services;

public class HttpService
{
    private readonly HttpClient _httpClient;
    //public string megaMilUrl;
    //"https://data.ny.gov/resource/d6yy-54nr.json";
    //public string powerBallURL;
    //https://data.ny.gov/resource/5xaw-6ayf.json
    private string lottoDataURL;

    public HttpService(string url)
    {
        _httpClient = new HttpClient();
        lottoDataURL = url;
    }

    public async Task<List<PbDrawing>> FetchPBDataAsync()
    {
        try
        {
            var response = await _httpClient.GetStringAsync(lottoDataURL);
            var drawingData = PbDrawing.FromJson(response);
            return drawingData;
        }
        catch (Exception ex)
        {
            // Handle exceptions
            Console.WriteLine($"An error occurred: {ex.Message}");
            return null;
        }
    }

    public async Task<List<MmDrawing>> FetchMMDataAsync()
    {
        try
        {
            var response = await _httpClient.GetStringAsync(lottoDataURL);
            var drawingData = MmDrawing.FromJson(response);
            return drawingData;
        }
        catch (Exception ex)
        {
            // Handle exceptions
            Console.WriteLine($"An error occurred: {ex.Message}");
            return null;
        }
    }
}