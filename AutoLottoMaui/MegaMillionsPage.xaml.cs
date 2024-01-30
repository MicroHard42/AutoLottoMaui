using AutoLottoMaui.ViewModels;

namespace AutoLottoMaui;

public partial class MegaMillionsPage : ContentPage
{

	MegaMillionsViewModel _megaMillionsViewModel;
	public MegaMillionsPage()
	{
		InitializeComponent();
		_megaMillionsViewModel = (MegaMillionsViewModel)BindingContext;
        datePicker.Date = DateTime.Today.AddDays(-14);
        lotteryListView.ItemsSource = _megaMillionsViewModel.DrawingHistory.ToList();
	}

    private void OnItemSelected(object sender, DateChangedEventArgs e)
    {
        var selectedDate = e.NewDate;
        var filteredDraws = _megaMillionsViewModel.DrawingHistory.Where(draw => draw.DrawDate.Date >= selectedDate).ToList();

        // Update the ListView's ItemsSource to the filtered list
        lotteryListView.ItemsSource = filteredDraws;
    }
}