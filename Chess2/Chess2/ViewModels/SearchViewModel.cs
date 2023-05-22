namespace Chess2.ViewModels
{
    public class SearchViewModel : BindableBase
    {
		readonly SearchModel _model = new SearchModel();
		public SearchViewModel()
        {
			_model.PropertyChanged += (s, e) => RaisePropertiesChanged(e.PropertyName);
			CancelCommand = new DelegateCommand<string>(str =>
			{
				_model.IsCancel();
			});
		}
		public DelegateCommand<string> CancelCommand { get; }

		//public DelegateCommand CancelCommand => new(() => _pageService.ChangePage(new Menu()));
	}
}
