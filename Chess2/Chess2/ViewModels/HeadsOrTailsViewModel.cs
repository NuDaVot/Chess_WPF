

namespace Chess2.ViewModels
{
    public class HeadsOrTailsViewModel : BindableBase
    {
		readonly HeadsOrTailsModel _model = new HeadsOrTailsModel();

		public HeadsOrTailsViewModel()
        {
			_model.PropertyChanged += (s, e) => RaisePropertiesChanged(e.PropertyName);

		}
	}
}
