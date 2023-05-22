namespace Chess2.Model
{
    class SignInModel : BindableBase
	{
		MainWindowModel _mainWindow;
		public string Authorization = "/Resources/Pictures/Authorization.png";

		public SignInModel()
		{
			_mainWindow = MainWindowViewModel._metod;
		}
		public void IsAuthorization()
		{
			_mainWindow.Navipage("Menu.xaml");
		}
		public void IsCansel()
		{
			_mainWindow.Navipage("MenuA.xaml");
		}
	}
}
