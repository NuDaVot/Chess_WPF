using Chess2.Data;
using System.Windows.Media;
using System.Windows;

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
		public Visibility Visibility { get; set; }
		public List<User> GetAllUser() => _historyChessContext.Users.Where(i => i.Role == true).ToList();

		public AdminPanelModel(int place, string nick, int? rating, Visibility visibility, int id)
		{
			_mainWindow = MainWindowViewModel._metod;
			_historyChessContext = new HistoryChessContext();

			Place = place;
			Nick = nick;
			Rating = rating;
			Visibility = visibility;
			Id = id;
		}
		public void IsBack()
		{
			_mainWindow.Navipage("SignIn.xaml");
		}
	}
}
