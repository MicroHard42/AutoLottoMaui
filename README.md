# AutoLottoMaui
 Lottery winning numbers viewer built with MAUI.

 ** Mainly a demonstration of using native Barcode Scanning UIViewController with MAUI for iOS.

 Based on:
 https://www.hackingwithswift.com/example-code/media/how-to-scan-a-barcode
 https://learn.microsoft.com/en-us/dotnet/maui/platform-integration/invoke-platform-code?view=net-maui-8.0

 App is configured to scan ITF14 and QR Encoding formats.
 To add expected encoding formats relevant to you, add/remove in ScannerViewController.cs File:

 ```metadataOutput.WeakMetadataObjectTypes = new NSString[] {AVMetadataObjectType.ITF14Code.GetConstant(),AVMetadataObjectType.QRCode.GetConstant()};```
