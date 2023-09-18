using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Chess2.ViewModels
{
    public class SignInViewModel : BindableBase
    {
		readonly SignInModel _model = new SignInModel();
        public string UserLogin { get; set; }
        public string Password { get; set; }
        public string ErrorMessage { get; set; }
        public string ErrorMessageButton { get; set; }
        public string Authorization => _model.Authorization;

		public SignInViewModel()
		{
			_model.PropertyChanged += (s, e) => RaisePropertiesChanged(e.PropertyName);
		}
        public DelegateCommand AuthorizationCommand => new(() =>
        {
            Task.Run(async () =>
            {
                if (await _model.AuthorizationAsync(UserLogin, Password))
                {
                    await Application.Current.Dispatcher.InvokeAsync(async () =>
                    {
                        if (!UserSetting.Default.Status)
                            _model.IsBanned();
                        else if (UserSetting.Default.Role)
                            _model.IsAuthorization();
                        else
                            _model.IsAuthorization();
                    });
                }
                else
                    ErrorMessageButton = "Неверный логин или пароль";
            });
        });

        public DelegateCommand CanselCommand => new(() => _model.IsCansel());




    }
}
