namespace Chess2.ViewModels
{
    class MainWindowViewModel: BindableBase
    {
		static public MainWindowModel _metod = new MainWindowModel();
		public string Background => _metod.Background;

		public MainWindowViewModel()
		{
			_metod.PropertyChanged += (s, e) => RaisePropertiesChanged(e.PropertyName);
			ChangePage = new DelegateCommand<string>(str =>
			{
				_metod.Navipage(str);
			});
			
        }
		public string NamePage => _metod.NamePage;
		public DelegateCommand<string> ChangePage;

	}
}
