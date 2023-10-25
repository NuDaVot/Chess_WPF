

using Chess2.Views;

namespace Chess2.Model
{
    class ChooseColorModel : BindableBase
	{
		MainWindowModel _mainWindow;
		public string RedRect = "/Resources/Pictures/RedRect.png";
		public string BlackRect = "/Resources/Pictures/BlackRect.png";
		public string WhileRect = "/Resources/Pictures/WhileRect.png";
		public ChooseColorModel()
		{
			_mainWindow = MainWindowViewModel._metod;
		}
		public void IsBlack()
		{
			ChooseCollor.Default.IsWhite = false;

            _mainWindow.Navipage("GamePage.xaml");
		}
		public void IsWhite()
		{
            ChooseCollor.Default.IsWhite = true;
            _mainWindow.Navipage("GamePage.xaml");
		}

	}
}
