namespace Chess2.Model
{
	public class InfoModel:BindableBase
	{
		MainWindowModel _mainWindow;
		public InfoModel()
		{
			_mainWindow = MainWindowViewModel._metod;
		}
	}
}
