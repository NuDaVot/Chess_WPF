namespace Chess2.ViewModels
{
    public class SearchViewModel : BindableBase
    {
		readonly SearchModel _model = new SearchModel();
		public SearchViewModel()
        {
            _model.PropertyChanged += (s, e) => RaisePropertiesChanged(e.PropertyName);
            Task.Run(() =>
            {
                System.Threading.Thread.Sleep(7000);
                _model.IsChooseColor();

            });

        }
		public DelegateCommand CancelCommand => new( () =>
        {
            _model.IsCancel();
        });

    }
}
