namespace Chess2.ViewModels
{
    public class ProfileViewModel : BindableBase
    {
		readonly ProfileModel _model = new ProfileModel();
		public string CrossRed => _model.CrossRed;
		public string ChessBoard => _model.ChessBoard;
		public string ChessIcon => _model.ChessIcon;
		public string JackdawRed => _model.JackdawRed;
		public string JackdawGreen => _model.JackdawGreen;
		public string PercentRed => _model.PercentRed;
		public string Jackdaw => _model.Jackdaw;
		public string BlackRect => _model.BlackRect;
		public string WhiteRect => _model.WhiteRect;
		public string FastMode => _model.FastMode;


		public ProfileViewModel()
        {
			_model.PropertyChanged += (s, e) => RaisePropertiesChanged(e.PropertyName);

		}
	}
}
