namespace Chess2.ViewModels
{
    class GamePageViewModel :BindableBase
    {
		readonly GamePageModel _model = new GamePageModel();
		public string ProfileIcon => _model.ProfileIcon;
		public string Search => _model.Search;
		public GamePageViewModel()
		{
			_model.PropertyChanged += (s, e) => RaisePropertiesChanged(e.PropertyName);
			Black = new DelegateCommand<string>(str =>
			{
				_model.IsBlack();
			});
			White = new DelegateCommand<string>(str =>
			{
				_model.IsWhite();
			});
		}
		public DelegateCommand<string> Black { get; }
		public DelegateCommand<string> White { get; }
	}
}
