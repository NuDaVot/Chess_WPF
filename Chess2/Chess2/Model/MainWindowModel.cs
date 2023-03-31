

namespace Chess2.Model
{
    class MainWindowModel : BindableBase
	{
		private string _namePage ="MenuA.xaml";
		public string NamePage;
		public ImageBrush Background { get; set; }
		public MainWindowModel()
		{
			NamePage = _namePage;
			this.Background = new ImageBrush(new BitmapImage(new Uri(@"pack://application:,,,/Resources/Pictures/Background.png")));

		}
		public void Navipage(string vlue)
		{
			NamePage = vlue;
			RaisePropertiesChanged("NamePage");
		}
	}
}
