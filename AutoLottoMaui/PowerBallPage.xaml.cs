using AutoLottoMaui.ViewModels;
namespace AutoLottoMaui;

public partial class PowerBallPage : ContentPage
{

    PowerBallViewModel _powerballViewModel;
    public PowerBallPage()
    {
        InitializeComponent();
        _powerballViewModel = (PowerBallViewModel)BindingContext;
        datePicker.Date = DateTime.Today.AddDays(-14);
        lotteryListView.ItemsSource = _powerballViewModel.DrawingHistory.ToList();
    }

    private void OnItemSelected(object sender, DateChangedEventArgs e)
    {
        var selectedDate = e.NewDate;
        var filteredDraws = _powerballViewModel.DrawingHistory.Where(draw => draw.DrawDate.Date >= selectedDate).ToList();

        // Update the ListView's ItemsSource to the filtered list
        lotteryListView.ItemsSource = filteredDraws;
    }

}