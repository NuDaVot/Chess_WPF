namespace Chess2.ViewModels
{
    public class SignInViewModel : BindableBase
    {
		readonly SignInModel _model = new SignInModel();

		public SignInViewModel()
		{
			_model.PropertyChanged += (s, e) => RaisePropertiesChanged(e.PropertyName);
			AuthorizationCommand = new DelegateCommand<string>(str =>
			{
				_model.IsAuthorization();
			});
			CanselCommand = new DelegateCommand<string>(str =>
			{
				_model.IsCansel();
			});

		}
		public DelegateCommand<string> AuthorizationCommand { get; }
		public DelegateCommand<string> CanselCommand { get; }
		//public DelegateCommand AuthorizationCommand => new(() => _pageService.ChangePage(new Menu()));
		//      public DelegateCommand CanselCommand => new(() => _pageService.ChangePage(new MenuA()));
	}
}
