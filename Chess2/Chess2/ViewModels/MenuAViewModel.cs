namespace Chess2.ViewModels
{
    public class MenuAViewModel : BindableBase
    {
		readonly MenuAModel _model = new MenuAModel();
		public MenuAViewModel()
		{
			_model.PropertyChanged += (s, e) => RaisePropertiesChanged(e.PropertyName);
			SignInCommand = new DelegateCommand<string>(str =>
			{
				_model.IsSignIn();
			});
			SignUpCommand = new DelegateCommand<string>(str =>
			{
				_model.IsSignUp();
			});
			LeaderboardCommand = new DelegateCommand<string>(str =>
			{
				_model.IsLeaderboard();
			});
		}
		public DelegateCommand<string> SignInCommand { get; }
		public DelegateCommand<string> SignUpCommand { get; }
		public DelegateCommand<string> LeaderboardCommand { get; }

		//public DelegateCommand SignInCommand => new(() => _pageService.ChangePage(new SignIn()));
		//public DelegateCommand SignUpCommand => new(() => _pageService.ChangePage(new SignUp()));
		//      public DelegateCommand LeaderboardCommand => new(() => _pageService.ChangePage(new Leaderboard()));
	}
}
