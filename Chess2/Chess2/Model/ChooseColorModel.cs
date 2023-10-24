﻿

using Chess2.Views;

namespace Chess2.Model
{
    class ChooseColorModel : BindableBase
	{
		MainWindowModel _mainWindow;
		public string RedRect = "/Resources/Pictures/RedRect.png";
		public string BlackRect = "/Resources/Pictures/BlackRect.png";
		public string WhileRect = "/Resources/Pictures/WhileRect.png";
		public ChooseColorModel()
		{
			_mainWindow = MainWindowViewModel._metod;
		}
		public void IsBlack()
		{
			_mainWindow.isWhite = false;

            _mainWindow.Navipage("GamePage.xaml");
		}
		public void IsWhite()
		{
            _mainWindow.isWhite = true;
            _mainWindow.Navipage("GamePage.xaml");
		}

	}
}
