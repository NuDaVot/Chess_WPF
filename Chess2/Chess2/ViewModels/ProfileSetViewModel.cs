namespace Chess2.ViewModels
{
   public class ProfileSetViewModel : BindableBase
   {
		readonly ProfileSetModel _model = new ProfileSetModel();
		public ProfileSetViewModel()
        {
			_model.PropertyChanged += (s, e) => RaisePropertiesChanged(e.PropertyName);

		}
	}
}
