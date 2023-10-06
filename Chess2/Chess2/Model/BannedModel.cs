namespace Chess2.Model
{
    class BannedModel : BindableBase
    {
        MainWindowModel _mainWindow;
        public BannedModel()
        {
            _mainWindow = MainWindowViewModel._metod;
        }
        public void IsAle()
        {
            _mainWindow.Navipage("MenuA.xaml");
        }
    }
}
