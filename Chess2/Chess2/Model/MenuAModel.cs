namespace Chess2.Model
{
    class MenuAModel : BindableBase
	{
		MainWindowModel _mainWimdow;
		public MenuAModel()
		{
			_mainWimdow = MainWindowViewModel._metod;
		}
	}
}
