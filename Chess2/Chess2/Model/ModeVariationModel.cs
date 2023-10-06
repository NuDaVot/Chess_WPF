

namespace Chess2.Model
{
    class ModeVariationModel : BindableBase
    {
		MainWindowModel _mainWindow;
		public string RedRect = "/Resources/Pictures/RedRect.png";
		public string Icon = "/Resources/Pictures/Icon.png";
		public string FastMode = "/Resources/Pictures/FastMode.png";

		public ModeVariationModel()
		{
			_mainWindow = MainWindowViewModel._metod;
		}
		public void IsSignIn()
		{
			_mainWindow.Navipage("SignIn.xaml");
		}
	}
}
