using AutoLottoMaui.ViewModels;
using Microsoft.Maui.Platform;
using UIKit;

namespace AutoLottoMaui.Services;

public partial class ScannerHandler{
    private BarcodeViewModel _viewModel;

        public ScannerHandler(BarcodeViewModel viewModel)
    {
        _viewModel = viewModel;
    }

public partial void ShowScanner(){
    var currentUIViewController = Platform.GetCurrentUIViewController();
    if (currentUIViewController != null)
    {
        var scannerViewController = new ScannerViewController();
            scannerViewController.BarcodeScanned += HandleDataScanned;
        currentUIViewController.PresentViewController(scannerViewController, true, null);
    }
}
    private void HandleDataScanned(string barcodeData)
    {
        
            _viewModel.BarcodeValue = barcodeData;
    }
}