
using Chess2.Views;

namespace Chess2.Model
{
    class MenuModel : BindableBase
	{
		MainWindowModel _mainWindow;
		public string Icon = "/Resources/Pictures/Icon.png";
		public string ProfileIcon = "/Resources/Pictures/ProfileIcon.png";

		public MenuModel()
		{
			_mainWindow = MainWindowViewModel._metod;
		}
		public void IsSearch()
		{
			_mainWindow.Navipage("Search.xaml");
		}
		public void IsExit()
		{
			_mainWindow.Navipage("MenuA.xaml");
		}
		public void IsLeaderboard()
		{
			_mainWindow.Navipage("Leaderboard.xaml");
			LeaderboardModel.MenuAOrMenu = false;
		}
		public void IsProfile()
		{
			_mainWindow.Navipage("Profile.xaml");
		}
	}
}
