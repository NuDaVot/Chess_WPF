using Microsoft.VisualBasic.Logging;
using Chess2.Data;
using System.Security.Cryptography;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Chess2.ViewModels
{
    public class ProfileSetViewModel : BindableBase
    {
        readonly ProfileSetModel _model = new ProfileSetModel();

        public User UserCst = new User();

        public List<User> UsersCollect { get; set; }

        public string Nick { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string NewPassword { get; set; }

        public string ConfirmNewPass { get; set; }

        public int Iduser { get; set; }

        public ProfileSetViewModel()
        {
            _model.PropertyChanged += (s, e) => RaisePropertiesChanged(e.PropertyName);
            var users = _model.GetAllUserNick();
            UsersCollect = users;
        }
        public DelegateCommand CanselCommand => new(() => _model.IsCansel());
        public AsyncCommand EditCommand => new(async () =>
        {
            string salt = BCrypt.Net.BCrypt.GenerateSalt(12);
            string hashedNewPassword = BCrypt.Net.BCrypt.HashPassword(NewPassword, salt);
            UserCst.Login = Login;
            UserCst.Password = hashedNewPassword;
            UserCst.Nick = Nick;
            UserCst.Iduser = Iduser;
            await _model.redactUser(UserCst, Password);
        }, bool () =>
        {
            if (string.IsNullOrWhiteSpace(Login)
            || string.IsNullOrWhiteSpace(Password)
            || string.IsNullOrWhiteSpace(Nick)
            || string.IsNullOrWhiteSpace(NewPassword)
            || string.IsNullOrWhiteSpace(ConfirmNewPass))
                return false;
            else if (UsersCollect.Any(i =>
            i.Login == Login && i.Iduser != UserSetting.Default.IdUser))
            {
                return false;
            }
            else if (UsersCollect.Any(i =>
            i.Nick == Nick && i.Iduser != UserSetting.Default.IdUser))
            {
                return false;
            }
            else if (ConfirmNewPass != NewPassword)
            {
                return false;
            }
            else
                return true;
        });
    }
}
