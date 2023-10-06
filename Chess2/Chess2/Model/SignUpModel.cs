namespace Chess2.Model
{
    class SignUpModel : BindableBase
    {
		MainWindowModel _mainWindow;
        HistoryChessContext _historyChessContext;
        public string Registr = "/Resources/Pictures/Registr.png";

		public SignUpModel()
		{
			_mainWindow = MainWindowViewModel._metod;
            _historyChessContext = new HistoryChessContext();

        }
		public void IsRegistr()
		{
			_mainWindow.Navipage("Menu.xaml");
		}
		public void IsCansel()
		{
			_mainWindow.Navipage("MenuA.xaml");
		}
        public async Task AddNewUser(string UserNick, string UserLogin, string UserPassword)
        {
            await _historyChessContext.Users.AddAsync(new User
            {
                Nick = UserNick,
                Login = UserLogin,
                Password = UserPassword,
            });
            await _historyChessContext.SaveChangesAsync();
        }
        public List<User> GetAllUserNick() => _historyChessContext.Users.ToList();

    }
}
