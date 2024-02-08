using AVFoundation;
using UIKit;
using Foundation;
using System;
using CoreFoundation;

namespace AutoLottoMaui;

public class ScannerViewController : UIViewController, IAVCaptureMetadataOutputObjectsDelegate
{
    AVCaptureSession captureSession;
    AVCaptureVideoPreviewLayer previewLayer;

    public delegate void BarcodeScannedDelegate(string barcodeData);
    public event BarcodeScannedDelegate BarcodeScanned;

    public override void ViewDidLoad()
    {
        base.ViewDidLoad();

        View.BackgroundColor = UIColor.Black;
        captureSession = new AVCaptureSession();

        var videoCaptureDevice = AVCaptureDevice.GetDefaultDevice(AVMediaTypes.Video);
        if (videoCaptureDevice == null)
        {
            Failed();
            return;
        }

        AVCaptureDeviceInput videoInput;
        try
        {
            videoInput = AVCaptureDeviceInput.FromDevice(videoCaptureDevice);
        }
        catch (Exception)
        {
            Failed();
            return;
        }

        if (captureSession.CanAddInput(videoInput))
            captureSession.AddInput(videoInput);
        else
        {
            Failed();
            return;
        }

        var metadataOutput = new AVCaptureMetadataOutput();
        if (captureSession.CanAddOutput(metadataOutput))
        {
            captureSession.AddOutput(metadataOutput);

            metadataOutput.SetDelegate(this, DispatchQueue.MainQueue);
            //Change array to add expected barcode Specs for detection
            metadataOutput.WeakMetadataObjectTypes = new NSString[] {AVMetadataObjectType.ITF14Code.GetConstant(),AVMetadataObjectType.QRCode.GetConstant()};
        }
        else
        {
            Failed();
            return;
        }

        previewLayer = new AVCaptureVideoPreviewLayer(captureSession)
        {
            Frame = View.Layer.Bounds,
            VideoGravity = AVLayerVideoGravity.ResizeAspectFill
        };
        View.Layer.AddSublayer(previewLayer);

        captureSession.StartRunning();
    }

    public override void ViewWillAppear(bool animated)
    {
        base.ViewWillAppear(animated);

        if (captureSession?.Running == false)
            captureSession.StartRunning();
    }

    public override void ViewWillDisappear(bool animated)
    {
        base.ViewWillDisappear(animated);

        if (captureSession?.Running == true)
            captureSession.StopRunning();
    }

    [Export("captureOutput:didOutputMetadataObjects:fromConnection:")]
    public void DidOutputMetadataObjects(AVCaptureMetadataOutput captureOutput, AVMetadataObject[] metadataObjects, AVCaptureConnection connection)
    {
        captureSession.StopRunning();

        if (metadataObjects.Length > 0)
        {
            var metadataObject = metadataObjects[0];
            if (metadataObject is AVMetadataMachineReadableCodeObject readableObject)
            {
                var stringValue = readableObject.StringValue;
                BarcodeScanned?.Invoke(stringValue);
            }
        }

        DismissViewController(true, null);
    }

    void Failed()
    {
        var alertController = UIAlertController.Create("Scanning not supported", "Your device does not support scanning a code from an item. Please use a device with a camera.", UIAlertControllerStyle.Alert);
        alertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
        PresentViewController(alertController, true, null);

        captureSession = null;
    }
}
