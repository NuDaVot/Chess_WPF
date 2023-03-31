
namespace Chess2.Model
{
    class LeaderboardModel : BindableBase
	{
		MainWindowModel _mainWimdow; 
		public LeaderboardModel()
		{
			_mainWimdow = MainWindowViewModel._metod;
		}
	}
}
