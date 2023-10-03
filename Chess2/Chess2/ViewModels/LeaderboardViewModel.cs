using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;

namespace Chess2.ViewModels
{
    public class LeaderboardViewModel : BindableBase
    {
		readonly LeaderboardModel _model = new LeaderboardModel(0, "",0, Visibility.Visible,0);
		public string Ramka => _model.Ramka;
        public string King => _model.King;
        public string Nick { get; set; }
        public Visibility BV { get; set; } = Visibility.Visible;
        public Visibility SVV { get; set; } = Visibility.Visible;

        public string Search
        {
            get { return GetValue<string>(); }
            set { SetValue(value, changedCallback: SearchPlayer); }
        }
        public int? Rating { get; set; }
        public int place { get; set; } = 2;


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
                nick = nick.Where(p => p.Nick.Contains(Search)).ToList();
                foreach (var i in Players)
                {
                    foreach (var j in nick)
                    {
                        if (j != personWithMaxAge)
                        {
                            BV = Visibility.Collapsed;
                            if (i.Nick.Contains(j.Nick) || i.Nick == j.Nick) // equals
                            {
                                i.Visibility = Visibility.Visible;
                            }
                            else
                            {
                                i.Visibility = Visibility.Collapsed;
                            }
                        }
                        else BV = Visibility.Visible;
                    }
                }

                //bool allCollapsed = Players.All(item => item.Visibility == Visibility.Collapsed);

                //if (nick.Count == 0 && allCollapsed)
                //    SVV = Visibility.Collapsed;
                //else SVV = Visibility.Visible;


            }
            else
            {
                if(Players.Count == 0) 
                {
                    foreach (var i in players)
                    {
                        if (i != personWithMaxAge)
                            Players.Add(new LeaderboardModel(place++, i.Nick, i.Rating, Visibility.Visible, i.Iduser));
                    }
                }
                else
                {
                    BV = Visibility.Visible;
                    foreach (var i in Players)
                    {
                        i.Visibility = Visibility.Visible;  
                    }
                }
                
            }
            

        }
        public DelegateCommand CancelCommand => new(() => _model.IsCancel());
        public DelegateCommand SignUpCommand { get; set; }
	}

}
