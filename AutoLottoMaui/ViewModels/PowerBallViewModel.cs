using System.Collections.ObjectModel;
using System.Windows.Input;
using AutoLottoMaui.Models;
using AutoLottoMaui.Services;

namespace AutoLottoMaui.ViewModels;
public class PowerBallViewModel : BaseViewModel
{
    private ObservableCollection<Drawing> _drawing;
    private string _statusMessage;
    private readonly HttpService _httpService;

    public ObservableCollection<Drawing> DrawingHistory
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
    public ICommand FetchDataCommand { get; }

    public PowerBallViewModel()
    {
        _drawing = new ObservableCollection<Drawing>();
        _httpService = new HttpService("https://data.ny.gov/resource/d6yy-54nr.json");
        FetchDataAsync();
    }



    private async void FetchDataAsync()
    {
        try
        {
            StatusMessage = "Fetching data...";
            var drawingsList = await _httpService.FetchDataAsync();

            foreach (Drawing draw in drawingsList)
            {
                DrawingHistory.Add(draw);
            }

            StatusMessage = "Data fetched successfully!";
        }
        catch (Exception ex)
        {
            StatusMessage = $"Error fetching data: {ex.Message}";
        }
    }
}


