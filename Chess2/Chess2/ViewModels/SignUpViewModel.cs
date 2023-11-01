using Chess2.Data;
using System.Security.Cryptography;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Chess2.ViewModels
{
    public class SignUpViewModel : BindableBase
    {
		readonly SignUpModel _model = new SignUpModel();
        HistoryChessContext _historyChessContext;

        public string UserNick { get; set; }
        public string UserLogin { get; set; }
        public string UserPassword { get; set; }
        public string UserPassword1 { get; set; }
        public string ErrorMessageAllField { get; set; }  
        public string ErrorMessageLogin { get; set; } 
        public string ErrorMessageNick { get; set; } 
        public string ErrorMessagePassword { get; set; }
        public List<User> users1 { get; set; }



        public string Registr => _model.Registr;
		public SignUpViewModel()
        {
            _historyChessContext = new HistoryChessContext();
            var users = _model.GetAllUserNick();
            users1 = users;
            _model.PropertyChanged += (s, e) => RaisePropertiesChanged(e.PropertyName);
		}
        public AsyncCommand RegistrCommand => new(async() =>
        {
            string salt = BCrypt.Net.BCrypt.GenerateSalt(12);
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(UserPassword, salt);
            await _model.AddNewUser(UserNick, UserLogin, hashedPassword);
            var users = _model.GetAllUserNick().SingleOrDefault(u => u.Nick == UserNick);
			UserSetting.Default.Rating = 0;
			UserSetting.Default.Nick = UserNick;
			UserSetting.Default.Login = UserLogin;
			UserSetting.Default.Password = UserPassword;
			UserSetting.Default.IdUser = users.Iduser;
			_model.IsRegistr();
		}, bool () =>
        {
            if (string.IsNullOrWhiteSpace(UserNick)
                || string.IsNullOrWhiteSpace(UserLogin)
                || string.IsNullOrWhiteSpace(UserPassword)
                || string.IsNullOrWhiteSpace(UserPassword1))
            {

                ErrorMessageAllField = "*Все поля обязательны для заполнения";
                return false;
            }
            else if (users1.Any(i => i.Login == UserLogin || i.Login.ToLower() == UserLogin.ToLower()))
            {
                ErrorMessageLogin = "Логин занят";
				return false;
			}
			else if (users1.Any(i => i.Nick == UserNick))
            {
                ErrorMessageNick = "Никнейм занят";
				return false;

			}
			else if (UserPassword != UserPassword1)
            {
                ErrorMessagePassword = "Пароли не совпадают";
				return false;
			}
			else
            {
                ErrorMessageLogin = string.Empty;
                ErrorMessagePassword = string.Empty;
                ErrorMessageNick = string.Empty;
                ErrorMessageAllField = string.Empty;
				return true;
			}
			
		});

        public DelegateCommand CanselCommand => new(() => _model.IsCansel());
    }
}
