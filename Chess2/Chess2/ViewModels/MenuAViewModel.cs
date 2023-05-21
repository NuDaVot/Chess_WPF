namespace Chess2.ViewModels
{
    public class MenuAViewModel : BindableBase
    {
		readonly MenuAModel _model = new MenuAModel();
		public string Icon => _model.Icon;

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

	}
}
