namespace Chess2.ViewModels
{
    public class SignUpViewModel : BindableBase
    {
		readonly SignUpModel _model = new SignUpModel();

		public SignUpViewModel()
        {
			_model.PropertyChanged += (s, e) => RaisePropertiesChanged(e.PropertyName);
			RegistrCommand = new DelegateCommand<string>(str =>
			{
				_model.IsRegistr();
			});
			CanselCommand = new DelegateCommand<string>(str =>
			{
				_model.IsCansel();
			});
		}
		public DelegateCommand<string> RegistrCommand { get; }
		public DelegateCommand<string> CanselCommand { get; }
		//public DelegateCommand RegistrCommand => new(() => _pageService.ChangePage(new Menu()));
		//public DelegateCommand CanselCommand => new(() => _pageService.ChangePage(new MenuA()));
	}
}
