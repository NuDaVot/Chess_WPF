using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace Chess2.ViewModels
{
    public class ProfileViewModel : BindableBase
    {
		readonly ProfileModel _model = new ProfileModel();
		public string CrossRed => _model.CrossRed;
        public string Cross => _model.Cross;
        public string Percent => _model.Percent;
        public string ChessBoard => _model.ChessBoard;
		public string ChessIcon => _model.ChessIcon;
		public string JackdawRed => _model.JackdawRed;
		public string JackdawGreen => _model.JackdawGreen;
		public string PercentRed => _model.PercentRed;
		public string Jackdaw => _model.Jackdaw;
		public string BlackRect => _model.BlackRect;
		public string WhiteRect => _model.WhiteRect;
		public string FastMode => _model.FastMode;
        public string ClassicMode => _model.ClassicMode;
		public string ProfileIcon => _model.ProfileIcon;

		public string Variable1 { get; set; }
        public string Variable2 { get; set; }
        public int Partys { get; set; } = 0;
        public int Wins { get; set; } = 0;
        public int Losses { get; set; } = 0;
        public int Draws { get; set; } = 0;
        public ObservableCollection<DBParty> Parties { get; set; }

        public ProfileViewModel()
        {
			_model.PropertyChanged += (s, e) => RaisePropertiesChanged(e.PropertyName);
            var parties = _model.GetParty().Where(p => p.WhiteUser == UserSetting.Default.IdUser || p.BlackUser == UserSetting.Default.IdUser).ToList();
            Parties = new ObservableCollection<DBParty>(parties);
            Parties.ForEach(data =>
            {
                data.ModeImage = data.Mode == true ? ClassicMode : FastMode;
                if (data.Result == 0) data.ResultImage = Jackdaw;
                else if(data.Result == 1) data.ResultImage = Cross;
                else data.ResultImage = Percent;
                data.WhiteUserImage = WhiteRect;
                data.BlackUserImage = BlackRect;
            });
            Variable1 = UserSetting.Default.Nick;
			Variable2 = UserSetting.Default.Rating.ToString();
            var party = _model.GetParty().Where(p => p.WhiteUser == UserSetting.Default.IdUser || p.BlackUser == UserSetting.Default.IdUser).ToList();
            Partys = party.Count;
            foreach (var party1 in party)
            {
                if (party1.Result == 0 && party1.WhiteUser == UserSetting.Default.IdUser)
                    Wins++;
                else if (party1.Result == 1 && party1.WhiteUser == UserSetting.Default.IdUser)
                    Losses++;
                else if (party1.Result == 1 && party1.BlackUser == UserSetting.Default.IdUser)
                    Wins++;
                else if (party1.Result == 0 && party1.BlackUser == UserSetting.Default.IdUser)
                    Losses++;
                else Draws++;
            }
        }
        public DelegateCommand BackCommand => new (() => _model.IsBack());
		public DelegateCommand ProfileCommand => new(() => _model.IsProfile());

		public AsyncCommand ReportCommand => new(async() =>
        {
            await _model.GetReport();
        });
    }
}
