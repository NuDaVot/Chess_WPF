namespace Chess2.ViewModels
{
    class MainWindowViewModel: BindableBase
    {
		static public MainWindowModel _metod = new MainWindowModel();
		public ImageBrush Background { get; set; }
		public MainWindowViewModel()
		{
			_metod.PropertyChanged += (s, e) => RaisePropertiesChanged(e.PropertyName);
			ChangePage = new DelegateCommand<string>(str =>
			{
				_metod.Navipage(str);
			});
			this.Background = new ImageBrush(new BitmapImage(new Uri(@"pack://application:,,,/Resources/Pictures/Background.png")));

        }
		public string NamePage => _metod.NamePage;
		public DelegateCommand<string> ChangePage;
	}
}
