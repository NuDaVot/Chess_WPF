namespace Chess2.ViewModels
{
    public class BannedViewModel : BindableBase
    {
        readonly BannedModel _model = new BannedModel();

        public BannedViewModel()
        {
            _model.PropertyChanged += (s, e) => RaisePropertiesChanged(e.PropertyName);
            CanselCommand = new DelegateCommand<string>(str =>
            {
                _model.IsAle();
            });
        }
        public DelegateCommand<string> CanselCommand { get; }
    }
}
