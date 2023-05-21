namespace Chess2.ViewModels
{
    public class MenuViewModel : BindableBase
    {
		readonly MenuModel _model = new MenuModel();

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
		}
		public DelegateCommand<string> SearchCommand { get; }
		public DelegateCommand<string> ExitCommand { get; }
		public DelegateCommand<string> LeaderboardCommand { get; }
		//public DelegateCommand SearchCommand => new(() => _pageService.ChangePage(new Search()));
		//      public DelegateCommand ExitCommand => new(() => _pageService.ChangePage(new MenuA()));
		//      public DelegateCommand LeaderboardCommand => new(() => _pageService.ChangePage(new Leaderboard()));

	}
}
