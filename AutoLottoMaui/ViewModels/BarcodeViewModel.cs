using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AutoLottoMaui.ViewModels
{
	public class BarcodeViewModel : BaseViewModel
	{
		private string _barcodeValue;

		public string BarcodeValue
		{
			get => _barcodeValue;
			set
			{
				_barcodeValue = value;
				OnPropertyChanged(nameof(BarcodeValue));
			}
		}
	}
}

