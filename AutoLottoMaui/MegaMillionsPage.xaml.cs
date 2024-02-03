using AutoLottoMaui.ViewModels;

namespace AutoLottoMaui;

public partial class MegaMillionsPage : ContentPage
{

	MegaMillionsViewModel _megaMillionsViewModel;
	public MegaMillionsPage()
	{
		InitializeComponent();
		_megaMillionsViewModel = (MegaMillionsViewModel)BindingContext;
	}

    private void OnItemSelected(object sender, DateChangedEventArgs e)
    {
        
        // Update the ListView's ItemsSource to the filtered list
    }
}