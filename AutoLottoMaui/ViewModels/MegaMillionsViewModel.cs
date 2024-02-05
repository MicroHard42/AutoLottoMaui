using System.Collections.ObjectModel;
using System.Windows.Input;
using AutoLottoMaui.Models;
using AutoLottoMaui.Services;
using AutoLottoMaui.Overloads;

namespace AutoLottoMaui.ViewModels;
public class MegaMillionsViewModel : BaseViewModel
{
    private RangeObservableCollection<MmDrawing> _drawing;
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

    public RangeObservableCollection<MmDrawing> DrawingHistory
    {
        get => _drawing;
        set
        {
            _drawing = value;
            OnPropertyChanged(nameof(DrawingHistory));
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

    public MegaMillionsViewModel()
    {
        _drawing = new RangeObservableCollection<MmDrawing>();
        _httpService = new HttpService("https://data.ny.gov/resource/d6yy-54nr.json");
        FetchDataCommand = new Command(async () => await FetchDataAsync());
    }



    private async Task FetchDataAsync()
    {

        if (IsLoading) { return; }

        IsLoading = true;

        try
        {
            StatusMessage = "Fetching data...";
            var drawingsList = await _httpService.FetchMMDataAsync();

            DrawingHistory.AddRange(drawingsList);
            OnPropertyChanged(nameof(DrawingHistory));


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
