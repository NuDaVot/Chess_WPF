namespace Chess2.Model
{
    public class LeaderboardModel : BindableBase
	{
		MainWindowModel _mainWindow;
        HistoryChessContext _historyChessContext;


        public static bool MenuAOrMenu;
		public string Ramka = "/Resources/Pictures/Ramka.png";
        public string King = "/Resources/Pictures/King.png";
        public string Nick { get; set; }
        public int Place { get; set; }
        public int? Rating { get; set; }
        public List<User> GetAllUser() => _historyChessContext.Users.ToList();

        public LeaderboardModel(int place, string nick, int? rating)
		{
			_mainWindow = MainWindowViewModel._metod;
            _historyChessContext = new HistoryChessContext();
            
            Place = place;
            Nick = nick;
            Rating = rating;
        }
		public void IsCancel()
		{
			if (MenuAOrMenu)
                _mainWindow.Navipage("MenuA.xaml");
            else _mainWindow.Navipage("Menu.xaml");

		}
        
    }
}
