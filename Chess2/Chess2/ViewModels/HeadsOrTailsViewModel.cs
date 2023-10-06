

namespace Chess2.ViewModels
{
    public class HeadsOrTailsViewModel : BindableBase
    {
		readonly HeadsOrTailsModel _model = new HeadsOrTailsModel();
		public string Orel => _model.Orel;
		public string Reshka => _model.Reshka;
		public HeadsOrTailsViewModel()
        {
			_model.PropertyChanged += (s, e) => RaisePropertiesChanged(e.PropertyName);

		}
	}
}
