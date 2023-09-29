namespace Chess2.ViewModels
{
    public class LeaderboardViewModel : BindableBase
    {
		readonly LeaderboardModel _model = new LeaderboardModel(0, "",0);
		public string Ramka => _model.Ramka;
        public string King => _model.King;
        public string Nick { get; set; }
        public Visibility BV {  get; set; }
        public string Search
        {
            get { return GetValue<string>(); }
            set { SetValue(value, changedCallback: SearchPlayer); }
        }
        public int? Rating { get; set; }
        public int place { get; set; } = 1;

        public static ObservableCollection<LeaderboardModel> Players { get; set; } = new ObservableCollection<LeaderboardModel>();


        public LeaderboardViewModel()
        {
            _model.PropertyChanged += (s, e) => RaisePropertiesChanged(e.PropertyName);
            SearchPlayer();
        }
        public void SearchPlayer()
        {
            var personWithMaxAge = _model.GetAllUser().OrderByDescending(player => player.Rating).First();
            Rating = personWithMaxAge.Rating;
            Nick = personWithMaxAge.Nick;
            var players = _model.GetAllUser().OrderByDescending(player => player.Rating);
            var nick = _model.GetAllUser();
            if (!string.IsNullOrWhiteSpace(Search))
            {
                Players.Clear();
                nick = nick.Where(p => p.Nick.ToString().ToLower().Contains(Search.ToLower())).ToList();

                foreach (var i in nick)
                {
                    if (i != personWithMaxAge)
                    {
                        BV = Visibility.Collapsed;
                        Players.Add(new LeaderboardModel(place, i.Nick, i.Rating));

                    }
                    else
                    {
                        BV = Visibility.Visible;
                        Players.Clear();
                    }
                }
            }
            else
            {
                Players.Clear();
                BV = Visibility.Visible;
                place = 0;
                foreach (var i in players)
                {
                    place++;
                    if (i != personWithMaxAge)
                        Players.Add(new LeaderboardModel(place, i.Nick, i.Rating));
                }
            }
           
        }
        public DelegateCommand CancelCommand => new(() => _model.IsCancel());
        public DelegateCommand SignUpCommand { get; set; }
	}

}
