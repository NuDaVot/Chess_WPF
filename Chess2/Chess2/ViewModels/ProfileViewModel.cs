namespace Chess2.ViewModels
{
    public class ProfileViewModel : BindableBase
    {
		readonly ProfileModel _model = new ProfileModel();

		public ProfileViewModel()
        {
			_model.PropertyChanged += (s, e) => RaisePropertiesChanged(e.PropertyName);

		}
	}
}
