namespace Chess2.Model
{
	public class InfoModel:BindableBase
	{
		MainWindowModel _mainWindow;
		public string PercentRed = "/Resources/Pictures/Percent.png";
		public string CrossRed = "/Resources/Pictures/Cross.png";
		public string ChessIcon = "/Resources/Pictures/Order.png";
		public string JackdawRed = "/Resources/Pictures/Jackdaw.png";
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
