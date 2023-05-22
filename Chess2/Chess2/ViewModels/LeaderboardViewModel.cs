

namespace Chess2.ViewModels
{
    public class LeaderboardViewModel : BindableBase
    {
		readonly LeaderboardModel _model = new LeaderboardModel();

		public LeaderboardViewModel()
        {
			_model.PropertyChanged += (s, e) => RaisePropertiesChanged(e.PropertyName);
			CancelCommand = new DelegateCommand<string>(str =>
			{
				_model.IsCancel();
			});
			//White = new DelegateCommand<string>(str =>
			//{
			//	_model.IsWhite();
			//});
		}
		public DelegateCommand<string> CancelCommand { get; }
		public DelegateCommand<string> SignUpCommand { get; }
	}

}
