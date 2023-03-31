

namespace Chess2.Model
{
    class ProfileSetModel : BindableBase
	{
		MainWindowModel _mainWimdow;
		public ProfileSetModel()
		{
			_mainWimdow = MainWindowViewModel._metod;
		}
	}
}
