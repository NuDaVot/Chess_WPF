namespace Chess2.Model
{
	public class InfoModel:BindableBase
	{
		MainWindowModel _mainWindow;
		public string PercentRed = "/Resources/Pictures/PercentRed.png";
		public string CrossRed = "/Resources/Pictures/RedCross.png";
		public string ChessIcon = "/Resources/Pictures/ChessIcon.png";
		public string JackdawRed = "/Resources/Pictures/JackdawRed.png";
		public void IsBack()
		{
			_mainWindow.Navipage("MenuA.xaml");
		}

		public InfoModel()
		{
			_mainWindow = MainWindowViewModel._metod;
		}
	}
}
