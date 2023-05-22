

using Chess2.ViewModels;

namespace Chess2.Model
{
    class SignUpModel : BindableBase
    {
		MainWindowModel _mainWindow;
		public SignUpModel()
		{
			_mainWindow = MainWindowViewModel._metod;
		}
		public void IsRegistr()
		{
			_mainWindow.Navipage("Menu.xaml");
		}
		public void IsCansel()
		{
			_mainWindow.Navipage("MenuA.xaml");
		}
	}
}
