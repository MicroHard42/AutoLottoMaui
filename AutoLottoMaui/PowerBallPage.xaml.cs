using AutoLottoMaui.ViewModels;
namespace AutoLottoMaui;

public partial class PowerBallPage : ContentPage
{

    PowerBallViewModel _powerballViewModel;
    public PowerBallPage()
    {
        InitializeComponent();
        _powerballViewModel = (PowerBallViewModel)BindingContext;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        if (!(BindingContext as PowerBallViewModel).DrawingHistory.Any())
        {
            (BindingContext as PowerBallViewModel).FetchDataCommand.Execute(null);
        }
    }

    private void OnItemSelected(object sender, DateChangedEventArgs e)
    {

        // Update the ListView's ItemsSource to the filtered list
    }

}