
namespace Chess2.Model
{
    class SignInModel : BindableBase
	{
		MainWindowModel _mainWindow;
        HistoryChessContext _historyChessContext;

        public string Authorization = "/Resources/Pictures/Authorization.png";

		public SignInModel()
		{
			_mainWindow = MainWindowViewModel._metod;
            _historyChessContext = new HistoryChessContext();

        }
        public void IsAuthorization()
		{
			_mainWindow.Navipage("Menu.xaml");
		}
		public void IsCansel()
		{
			_mainWindow.Navipage("MenuA.xaml");
		}
        public void IsBanned()
        {
            _mainWindow.Navipage("Banned.xaml");
        }
        public async Task<bool> AuthorizationAsync(string username, string password)
        {
            var user = await _historyChessContext.Users.SingleOrDefaultAsync(u => u.Login == username);
            if (user == null)
                return false;
            if (VerifyPassword(password, user.Password))
            {
                UserSetting.Default.Rating = (int)user.Rating;
                UserSetting.Default.Status = (bool)user.Status;
                UserSetting.Default.Nick = user.Nick;
                UserSetting.Default.Role = (bool)user.Role;
                UserSetting.Default.Login = user.Login;
                UserSetting.Default.Password = user.Password;
                UserSetting.Default.IdUser = user.Iduser;
                return true;
            }
            return false;
        }

        public static bool VerifyPassword(string enteredPassword, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(enteredPassword, hashedPassword);
        }
    }
}
