namespace Chess2.Model
{
    class ProfileSetModel : BindableBase
    {
        MainWindowModel _mainWindow;
        HistoryChessContext _historyChessContext;

        public ProfileSetModel()
        {
            _mainWindow = MainWindowViewModel._metod;
            _historyChessContext = new HistoryChessContext();
        }
        public void IsCansel()
        {
            _mainWindow.Navipage("MenuA.xaml");
        }
        public async Task redactUser(User UserCst, string oldPassword)
        {
            if (VerifyPassword(oldPassword, UserSetting.Default.Password))
            {
                User? user = await _historyChessContext.Users.FirstOrDefaultAsync(user => user.Iduser == UserSetting.Default.IdUser);
                if (user != null)
                {
                    user.Login = UserCst.Login;
                    user.Nick = UserCst.Nick;
                    user.Password = UserCst.Password;
                    await _historyChessContext.SaveChangesAsync();
                    MessageBox.Show("The changes are saved, please re-log in");
                    _mainWindow.Navipage("MenuA.xaml");
                }
                else
                {
                    MessageBox.Show("Something went wrong, the changes are not saved, please re-log in with your old password or register a new account");
                    _mainWindow.Navipage("MenuA.xaml");
                }
            }
            else
            {
                MessageBox.Show("Incorrect password");
            }
        }
        public static bool VerifyPassword(string enteredPassword, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(enteredPassword, hashedPassword);
        }
        public List<User> GetAllUserNick() => _historyChessContext.Users.ToList();
    }
}
