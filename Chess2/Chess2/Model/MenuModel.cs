
namespace Chess2.Model
{
    class MenuModel : BindableBase
	{
		MainWindowModel _mainWimdow;
		public MenuModel()
		{
			_mainWimdow = MainWindowViewModel._metod;
		}
	}
}
