using System.Collections.ObjectModel;
using System.Windows.Input;
using AutoLottoMaui.Models;
using AutoLottoMaui.Services;
using AutoLottoMaui.Overloads;

namespace AutoLottoMaui.ViewModels;
public class PowerBallViewModel : BaseViewModel
{
    private RangeObservableCollection<PbDrawing> _drawing;
    private string _statusMessage;
    private bool _isLoading;
    private readonly HttpService _httpService;


    public bool IsLoading
    {
        get => _isLoading;
        set
        {
            _isLoading = value;
            OnPropertyChanged();
        }
    }


    public RangeObservableCollection<PbDrawing> DrawingHistory
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
        _drawing = new RangeObservableCollection<PbDrawing>();

        _httpService = new HttpService("https://data.ny.gov/resource/5xaw-6ayf.json");
        FetchDataCommand = new Command(async () => { await FetchDataAsync(); });
    }



    private async Task FetchDataAsync()
    {

        if (IsLoading){ return; }

        IsLoading = true;

        try
        {
            StatusMessage = "Fetching data...";

            var drawingsList = await _httpService.FetchPBDataAsync();
            

            DrawingHistory.AddRange(drawingsList);

            StatusMessage = "Data fetched successfully!";
        }
        catch (Exception ex)
        {
            StatusMessage = $"Error fetching data: {ex.Message}";
        }

        finally
        {
            IsLoading = false;
        }
    }
}


