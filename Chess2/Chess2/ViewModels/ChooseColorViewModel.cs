
namespace Chess2.ViewModels
{
    public class ChooseColorViewModel : BindableBase
    {
		readonly ChooseColorModel _model = new ChooseColorModel();
		public string RedRect => _model.RedRect;
		public string BlackRect => _model.BlackRect;
		public string WhileRect => _model.WhileRect;
		public ChooseColorViewModel()
        {
			_model.PropertyChanged += (s, e) => RaisePropertiesChanged(e.PropertyName);
			Black = new DelegateCommand<string>(str =>
			{
				_model.IsBlack();
			});
			White = new DelegateCommand<string>(str =>
			{
				_model.IsWhite();
			});
		}
		public DelegateCommand<string> Black { get; }
		public DelegateCommand<string> White { get; }

	}
}
