
namespace Chess2.Model
{
    class LeaderboardModel : BindableBase
	{
		MainWindowModel _mainWindow;
		public static bool MenuAOrMenu;
		public LeaderboardModel()
		{
			_mainWindow = MainWindowViewModel._metod;
			
		}
		public void IsCancel()
		{
			if (MenuAOrMenu)
			{
				_mainWindow.Navipage("MenuA.xaml");
			}
			else _mainWindow.Navipage("Menu.xaml");

		}
	}
}
