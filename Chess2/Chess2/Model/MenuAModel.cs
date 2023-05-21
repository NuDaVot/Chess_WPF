namespace Chess2.Model
{
    class MenuAModel : BindableBase
	{
		MainWindowModel _mainWindow;
		public string Icon = "/Resources/Pictures/Icon.png";

		public MenuAModel()
		{
			_mainWindow = MainWindowViewModel._metod;
		}
		public void IsSignIn()
		{
			_mainWindow.Navipage("SignIn.xaml");
		}
		public void IsSignUp()
		{
			_mainWindow.Navipage("SignUp.xaml");
		}
		public void IsLeaderboard()
		{
			_mainWindow.Navipage("Leaderboard.xaml");
			LeaderboardModel.MenuAOrMenu = true;
		}
	}
}
