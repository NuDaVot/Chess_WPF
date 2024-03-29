﻿namespace Chess2.Model
{
    class MainWindowModel : BindableBase
	{
		private string _namePage = "MenuA.xaml";
		public string NamePage;
		public string Background = "Resources/Pictures/Background.png";
        public MainWindowModel()
		{
			NamePage = _namePage;
		}
		public void Navipage(string vlue)
		{
			NamePage = vlue;
            RaisePropertiesChanged("Background");
            RaisePropertiesChanged("NamePage");
		}
		public string GetPage()
		{
			return NamePage;
		}
	}
}
