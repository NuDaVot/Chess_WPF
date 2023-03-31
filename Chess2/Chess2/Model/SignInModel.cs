

namespace Chess2.Model
{
    class SignInModel : BindableBase
	{
		MainWindowModel _mainWimdow;
		public SignInModel()
		{
			_mainWimdow = MainWindowViewModel._metod;
		}
	}
}
