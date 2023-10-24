

namespace Chess2.Model
{
    class SearchModel : BindableBase
	{
		MainWindowModel _mainWindow;
		public SearchModel()
		{
			_mainWindow = MainWindowViewModel._metod;
		}
		public void IsCancel()
		{

			_mainWindow.Navipage("Menu.xaml");
		}
        public void IsChooseColor()
        {
            _mainWindow.Navipage("ChooseColor.xaml");
        }

    }
}
