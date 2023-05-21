namespace Chess2.ViewModels
{
    class ModeVariationViewModel : BindableBase
    {
		readonly ModeVariationModel _model = new ModeVariationModel();
		public string RedRect => _model.RedRect;
		public string FastMode => _model.FastMode;
		public string Icon => _model.Icon;

		public ModeVariationViewModel()
		{
			_model.PropertyChanged += (s, e) => RaisePropertiesChanged(e.PropertyName);
			SignInCommand = new DelegateCommand<string>(str =>
			{
				_model.IsSignIn();
			});
			
		}
		public DelegateCommand<string> SignInCommand { get; }
		public DelegateCommand<string> SignUpCommand { get; }
		public DelegateCommand<string> LeaderboardCommand { get; }

	}
}

