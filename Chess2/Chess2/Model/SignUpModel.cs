

using Chess2.ViewModels;

namespace Chess2.Model
{
    class SignUpModel : BindableBase
    {
		MainWindowModel _mainWimdow;
		public SignUpModel()
		{
			_mainWimdow = MainWindowViewModel._metod;
		}
	}
}
