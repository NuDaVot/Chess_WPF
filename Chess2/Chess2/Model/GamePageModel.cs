namespace Chess2.Model
{
    class GamePageModel:BindableBase
    {
		MainWindowModel _mainWindow;
		public string ProfileIcon = "/Resources/Pictures/ProfileIcon.png";
		public string Search = "/Resources/Pictures/Search.png";
		public GamePageModel()
		{
			_mainWindow = MainWindowViewModel._metod;
		}
		public void IsBlack()
		{
			_mainWindow.Navipage("SIgnInPage.xaml");
		}
		public void IsWhite()
		{
			_mainWindow.Navipage("SIgnInPage.xaml");
		}
	}
}
