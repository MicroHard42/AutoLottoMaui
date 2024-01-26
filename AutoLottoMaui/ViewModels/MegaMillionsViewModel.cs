using System.Collections.ObjectModel;
using AutoLottoMaui.Models;
using AutoLottoMaui.Services;

namespace AutoLottoMaui.ViewModels;
public class MyViewModel : BaseViewModel
{
    private Drawing _drawing;
    private string _statusMessage;
    private readonly HttpService _httpService;

    public Drawing Drawing
    {
        get => _drawing;
        set
        {
            _drawing = value;
            OnPropertyChanged();
        }
    }

    public string StatusMessage
    {
        get => _statusMessage;
        set
        {
            _statusMessage = value;
            OnPropertyChanged();
        }
    }

    public MyViewModel()
    {
        _httpService = new HttpService();
        FetchDataCommand = new Command(async () => await FetchDataAsync());
    }

    public Command FetchDataCommand { get; }

    private async Task FetchDataAsync()
    {
        try
        {
            StatusMessage = "Fetching data...";
            var Drawing = await _httpService.FetchDataAsync();

            StatusMessage = "Data fetched successfully!";
        }
        catch (Exception ex)
        {
            StatusMessage = $"Error fetching data: {ex.Message}";
        }
    }
}
