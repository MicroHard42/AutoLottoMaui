using System.Collections.ObjectModel;
using System.Windows.Input;
using AutoLottoMaui.Models;
using AutoLottoMaui.Services;

namespace AutoLottoMaui.ViewModels;
public class PowerBallViewModel : BaseViewModel
{
    private ObservableCollection<PbDrawing> _drawing;
    private string _statusMessage;
    private readonly HttpService _httpService;

    public ObservableCollection<PbDrawing> DrawingHistory
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
        _drawing = new ObservableCollection<PbDrawing>();
        _httpService = new HttpService("https://data.ny.gov/resource/5xaw-6ayf.json");
        FetchDataAsync();
    }



    private async void FetchDataAsync()
    {
        try
        {
            StatusMessage = "Fetching data...";
            var drawingsList = await _httpService.FetchPBDataAsync();

            foreach (PbDrawing draw in drawingsList)
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


