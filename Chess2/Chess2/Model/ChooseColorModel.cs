

namespace Chess2.Model
{
    class ChooseColorModel : BindableBase
	{
		MainWindowModel _mainWindow; 
		public ChooseColorModel()
		{
			_mainWindow = MainWindowViewModel._metod;
		}
		public void IsBlack()
		{
			_mainWindow.Navipage("SIgnInPage.xaml");
		}
		public void IsWhite()
		{
			_mainWindow.Navipage("SIgnInPage.xaml");
		}

	}
}
