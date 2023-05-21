namespace Chess2.ViewModels
{
    public class MenuViewModel : BindableBase
    {
		readonly MenuModel _model = new MenuModel();
		public string Icon => _model.Icon;
		public string ProfileIcon => _model.ProfileIcon;


		public MenuViewModel()
		{
			_model.PropertyChanged += (s, e) => RaisePropertiesChanged(e.PropertyName);
			SearchCommand = new DelegateCommand<string>(str =>
			{
				_model.IsSearch();
			});
			ExitCommand = new DelegateCommand<string>(str =>
			{
				_model.IsExit();
			});
			LeaderboardCommand = new DelegateCommand<string>(str =>
			{
				_model.IsLeaderboard();
			});
			ProfileCommand = new DelegateCommand<string>(str =>
			{
				_model.IsProfile();
			});
		}
		public DelegateCommand<string> SearchCommand { get; }
		public DelegateCommand<string> ExitCommand { get; }
		public DelegateCommand<string> LeaderboardCommand { get; }
		public DelegateCommand<string> ProfileCommand { get; }

	}
}
