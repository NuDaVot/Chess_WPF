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
        public ObservableCollection<LeaderboardModel> Players { get; set; } = new ObservableCollection<LeaderboardModel>();

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
				var itemsToCollapse = Players.Except(
							nick.Select(nick => new LeaderboardModel(0, "", 0, Visibility.Visible, 0) { Nick = nick.Nick }),
							new MyItemComparer()
						);
				foreach (var pair in itemsToCollapse)
				{
					pair.Visibility = Visibility.Collapsed;
				}
				foreach (var item in Players)
				{
					if (nick.Any(item2 => item2.Nick == item.Nick))
					{
						// Если есть совпадение, устанавливаем Visibility в Visible
						item.Visibility = Visibility.Visible;
					}
				}
				if (personWithMaxAge.Nick.Contains(Search)) BV = Visibility.Visible;
				else BV = Visibility.Collapsed;


				bool allCollapsed = Players.All(item => item.Visibility == Visibility.Collapsed);

				if (nick.Count == 0 && allCollapsed)
					SVV = Visibility.Collapsed;
				else SVV = Visibility.Visible;
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
					SVV = Visibility.Visible;
					Players.ForEach(item => item.Visibility = Visibility.Visible);

				}

			}          
        }
        public class MyItemComparer : IEqualityComparer<LeaderboardModel>
		{
			public bool Equals(LeaderboardModel x, LeaderboardModel y)
			{
				return x.Nick == y.Nick;
			}
			public int GetHashCode(LeaderboardModel obj)
			{
				return obj.Nick.GetHashCode();
			}
		}
        public DelegateCommand CancelCommand => new(() => _model.IsCancel());
        public DelegateCommand SignUpCommand { get; set; }
	}

}
