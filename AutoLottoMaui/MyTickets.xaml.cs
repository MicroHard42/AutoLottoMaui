using AutoLottoMaui.Services;
using AutoLottoMaui.ViewModels;

namespace AutoLottoMaui;

public partial class MyTickets : ContentPage
{
    ScannerHandler _scannerHandler;
    BarcodeViewModel barcodeViewModel;
    public MyTickets()
	{
        barcodeViewModel  = new BarcodeViewModel();
        _scannerHandler = new ScannerHandler((BarcodeViewModel)barcodeViewModel);
        this.BindingContext = barcodeViewModel;
        InitializeComponent();
    }

    public async void OnButtonClicked(object sender, EventArgs args)
    {
        await MainThread.InvokeOnMainThreadAsync(async () =>
        {
            _scannerHandler.ShowScanner();
        });
        
    }
    
}