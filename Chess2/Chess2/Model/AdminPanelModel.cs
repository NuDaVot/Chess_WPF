using Chess2.Data;
using System.Windows.Media;
using System.Windows;
using System.ComponentModel;

namespace Chess2.Model
{
    public class AdminPanelModel : BindableBase
    {
		MainWindowModel _mainWindow;
		HistoryChessContext _historyChessContext;

		public string Jackdaw = "/Resources/Pictures/Jackdaw.png";
		public string Percent = "/Resources/Pictures/Percent.png";
		public string Cross = "/Resources/Pictures/Cross.png";
		public string ChessBoard = "/Resources/Pictures/ChessBoard.png";
		public string FirstPlace = "/Resources/Pictures/FirstPlace.png";
		public string ChessIconWhite = "/Resources/Pictures/ChessIconWhite.png";
		public string Nick { get; set; }
		public int Place { get; set; }
		public int Id { get; set; }
		public int? Rating { get; set; }
        public int Partys { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int Draws { get; set; }
        public string Ban { get; set; }
        public Visibility Visibility { get; set; }
		public List<User> GetAllUser() => _historyChessContext.Users.Where(i => i.Role == true).ToList();
        public List<Party> GetAllParty() => _historyChessContext.Parties.ToList();


        public AdminPanelModel(int place, string nick, int? rating, Visibility visibility, int id, int partys, int wins, int losses, int draws, string ban)
		{
			_mainWindow = MainWindowViewModel._metod;
			_historyChessContext = new HistoryChessContext();

			Place = place;
			Nick = nick;
			Rating = rating;
			Visibility = visibility;
			Id = id;
			Partys = partys;
			Wins = wins;
			Losses = losses;
			Draws = draws;
			Ban = ban;

        }
		public void IsBack()
		{
			_mainWindow.Navipage("SignIn.xaml");
		}
       
    }
}
