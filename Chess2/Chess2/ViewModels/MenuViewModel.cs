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
		}
		public DelegateCommand SearchCommand => new(() => 
		{
                _model.IsSearch();

        });
        public DelegateCommand ExitCommand => new(() => _model.IsExit());
        public DelegateCommand LeaderboardCommand => new(() => _model.IsLeaderboard());
        public DelegateCommand ProfileCommand => new(() => _model.IsProfile());

	}
}
