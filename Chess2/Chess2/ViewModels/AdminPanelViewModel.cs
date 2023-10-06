namespace Chess2.ViewModels
{
    public class AdminPanelViewModel : BindableBase
	{
		readonly AdminPanelModel _model = new AdminPanelModel();
		public string Jackdaw => _model.Jackdaw;
		public string Percent => _model.Percent;
		public string Cross => _model.Cross;
		public string ChessBoard => _model.ChessBoard;
		public string FirstPlace => _model.FirstPlace;
		public string ChessIconWhite => _model.ChessIconWhite;


		public AdminPanelViewModel()
		{
			_model.PropertyChanged += (s, e) => RaisePropertiesChanged(e.PropertyName);

		}
        public DelegateCommand BackCommand => new(() => _model.IsBack());

    }
}
