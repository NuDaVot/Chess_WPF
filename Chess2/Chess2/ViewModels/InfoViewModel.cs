using Chess2.Data;
using System.Runtime.InteropServices;

namespace Chess2.ViewModels
{
	public class InfoViewModel:BindableBase
	{
		readonly InfoModel _model = new InfoModel();
		public string ChessIcon => _model.ChessIcon;
		public string JackdawRed => _model.JackdawRed;
		public string CrossRed => _model.CrossRed;
		public string PercentRed => _model.PercentRed;

		public DelegateCommand PerehodCommand => new(() =>
		{
			string url = "https://chess-boom.online/pravila-igry-v-shahmaty/";
			try { ShellExecute(IntPtr.Zero, "open", url, null, null, SW_SHOWNORMAL); }
			catch (Exception ex) { }
		});
		[DllImport("shell32.dll", SetLastError = true)]
		static extern IntPtr ShellExecute(IntPtr hwnd, string lpOperation, string lpFile, string lpParameters, string lpDirectory, int nShowCmd);

		private const int SW_SHOWNORMAL = 1;
		public InfoViewModel()
		{
			_model.PropertyChanged += (s, e) => RaisePropertiesChanged(e.PropertyName);
		}
		public DelegateCommand BackCommand => new(() => _model.IsBack());

	}
}
