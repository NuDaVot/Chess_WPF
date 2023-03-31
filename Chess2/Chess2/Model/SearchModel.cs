

namespace Chess2.Model
{
    class SearchModel : BindableBase
	{
		MainWindowModel _mainWimdow;
		public SearchModel()
		{
			_mainWimdow = MainWindowViewModel._metod;
		}
	}
}
