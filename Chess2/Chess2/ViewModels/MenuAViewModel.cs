namespace Chess2.ViewModels
{
    public class MenuAViewModel : BindableBase
    {
		readonly MenuAModel _model = new MenuAModel();
		public string Icon => _model.Icon;

		public MenuAViewModel()
		{
			_model.PropertyChanged += (s, e) => RaisePropertiesChanged(e.PropertyName);
		}
		public DelegateCommand SignInCommand => new(() => _model.IsSignIn());
        public DelegateCommand SignUpCommand => new(() => _model.IsSignUp());
        public DelegateCommand LeaderboardCommand => new(() => _model.IsLeaderboard());

    }
}
