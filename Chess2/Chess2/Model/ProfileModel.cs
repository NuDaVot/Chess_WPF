

namespace Chess2.Model
{
    class ProfileModel : BindableBase
	{
		MainWindowModel _mainWimdow;
		public ProfileModel()
		{
			_mainWimdow = MainWindowViewModel._metod;
		}
	}
}
