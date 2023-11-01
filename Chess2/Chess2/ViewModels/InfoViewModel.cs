using Chess2.Data;

namespace Chess2.ViewModels
{
	public class InfoViewModel:BindableBase
	{
		readonly InfoModel _model = new InfoModel();
		public InfoViewModel()
		{
			_model.PropertyChanged += (s, e) => RaisePropertiesChanged(e.PropertyName);
		}
	}
}
