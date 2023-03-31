

namespace Chess2.Model
{
    class ProfileModel : BindableBase
	{
		MainWindowModel _mainWindow;
		public ProfileModel()
		{
			_mainWindow = MainWindowViewModel._metod;
		}
	}
}
