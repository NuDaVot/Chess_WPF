

namespace Chess2.Model
{
    class ProfileSetModel : BindableBase
	{
		MainWindowModel _mainWindow;

		public ProfileSetModel()
		{
			_mainWindow = MainWindowViewModel._metod;
		}
	}
}
