namespace Chess2.ViewModels
{
    public class LeaderboardViewModel : BindableBase
    {
		readonly LeaderboardModel _model = new LeaderboardModel(0, "",0);
		public string Ramka => _model.Ramka;
        public string King => _model.King;
        public string Nick { get; set; }
        public Visibility BV { get; set; } = Visibility.Visible;
        public string Search
        {
            get { return GetValue<string>(); }
            set { SetValue(value, changedCallback: SearchPlayer); }
        }
        public int? Rating { get; set; }
        public int place { get; set; } = 1;
        public int place2 { get; set; } = 1;


        public static ObservableCollection<LeaderboardModel> Players { get; set; } = new ObservableCollection<LeaderboardModel>();
        public static ObservableCollection<LeaderboardModel> Players2 { get; set; } = new ObservableCollection<LeaderboardModel>();


        public LeaderboardViewModel()
        {
            _model.PropertyChanged += (s, e) => RaisePropertiesChanged(e.PropertyName);
            var players = _model.GetAllUser().OrderByDescending(player => player.Rating);

            foreach (var i in players)
            {
                Players2.Add(new LeaderboardModel(place2++, i.Nick, i.Rating));

            }
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

                foreach (var i in Players2)
                {
                    if (!i.Nick.Contains(personWithMaxAge.Nick))
                    {
                        BV = Visibility.Collapsed;
                        if (nick.Any(p => p.Nick == i.Nick))
                            Players.Add(new LeaderboardModel(i.Place, i.Nick, i.Rating));

                    }
                    else
                    {
                       
                        Players.Clear();
                        BV = Visibility.Visible;
                        //Players.Add(new LeaderboardModel(i.Place, i.Nick, i.Rating));

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
