

using System.Resources;

namespace Chess2.Model
{
    class HeadsOrTailsModel : BindableBase
    {
		MainWindowModel _mainWindow;
		public string Orel = "/Resources/Pictures/Orel.png";
		public string Reshka = "/Resources/Pictures/Reshka.png";
		public HeadsOrTailsModel()
		{
			_mainWindow = MainWindowViewModel._metod;
		}

	}
}
