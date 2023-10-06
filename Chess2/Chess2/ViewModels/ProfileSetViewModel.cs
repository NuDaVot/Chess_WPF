using Microsoft.VisualBasic.Logging;

namespace Chess2.ViewModels
{
   public class ProfileSetViewModel : BindableBase
   {
		readonly ProfileSetModel _model = new ProfileSetModel();

        public User UserCst { get; set; }

        public ObservableCollection<User> UsersCollect { get; set; }

        public string Nick { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string ConfirmPass { get; set; }

        public int Iduser { get; set; }

        public ProfileSetViewModel()
        {
			_model.PropertyChanged += (s, e) => RaisePropertiesChanged(e.PropertyName);
            //UsersCollect = _model.getAllUsers();
            Login = UserSetting.Default.Login;
            Nick = UserSetting.Default.Nick;
            Password = UserSetting.Default.Password;
        }
        //public AsyncCommand EditCommand => new(async () =>
        //{
        //    UserCst.Login = Login;
        //    UserCst.Password = Password;
        //    UserCst.Nick = Nick;
        //    UserCst.Iduser = Iduser;

        //    await _model.redactUser(UserCst, UsersCollect);
        //}, bool () =>
        //{
        //    if (string.IsNullOrWhiteSpace(Login)
        //    || string.IsNullOrWhiteSpace(Password)
        //    || string.IsNullOrWhiteSpace(Nick))
        //        return false;
        //    else if(ConfirmPass != Password)
        //    {
        //        return false;
        //    }
        //    else return true;
        //});
        //public DelegateCommand MenuCommand => new(() => _model.isGoBack());
    }
}
