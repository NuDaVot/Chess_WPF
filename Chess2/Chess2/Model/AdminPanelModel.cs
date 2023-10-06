namespace Chess2.Model
{
    class AdminPanelModel : BindableBase
	{
		MainWindowModel _mainWindow;
		public string Jackdaw = "/Resources/Pictures/Jackdaw.png";
		public string Percent = "/Resources/Pictures/Percent.png";
		public string Cross = "/Resources/Pictures/Cross.png";
		public string ChessBoard = "/Resources/Pictures/ChessBoard.png";
		public string FirstPlace = "/Resources/Pictures/FirstPlace.png";
		public string ChessIconWhite = "/Resources/Pictures/ChessIconWhite.png";

		public AdminPanelModel()
		{
			_mainWindow = MainWindowViewModel._metod;
		}
		public void IsBlack()
		{
			_mainWindow.Navipage("SIgnInPage.xaml");
		}
	}
}
