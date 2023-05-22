

namespace Chess2.Model
{
    class HeadsOrTailsModel : BindableBase
    {
		MainWindowModel _mainWindow;
		public HeadsOrTailsModel()
		{
			_mainWindow = MainWindowViewModel._metod;
		}

	}
}
