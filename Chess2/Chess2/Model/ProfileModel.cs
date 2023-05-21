

namespace Chess2.Model
{
    class ProfileModel : BindableBase
	{
		MainWindowModel _mainWindow;
		public string CrossRed = "/Resources/Pictures/CrossRed.png";
		public string ChessBoard = "/Resources/Pictures/ChessBoard.png";
		public string ChessIcon = "/Resources/Pictures/ChessIcon.png";
		public string JackdawRed = "/Resources/Pictures/JackdawRed.png";
		public string PercentRed = "/Resources/Pictures/PercentRed.png";
		public string JackdawGreen = "/Resources/Pictures/JackdawGreen.png";
		public string Jackdaw = "/Resources/Pictures/Jackdaw.png";
		public string BlackRect = "/Resources/Pictures/BlackRect.png";
		public string WhiteRect = "/Resources/Pictures/WhiteRect.png";
		public string FastMode = "/Resources/Pictures/FastMode.png";

		public ProfileModel()
		{
			_mainWindow = MainWindowViewModel._metod;
		}
		
	}
}
