using System.Linq;
using System.Windows.Media;

namespace Chess2.ViewModels
{
    public class AdminPanelViewModel : BindableBase
	{
		readonly AdminPanelModel _model = new AdminPanelModel(0, "", 0, Visibility.Visible, 0);
		public string Jackdaw => _model.Jackdaw;
		public string Percent => _model.Percent;
		public string Cross => _model.Cross;
		public string ChessBoard => _model.ChessBoard;
		public string FirstPlace => _model.FirstPlace;
		public string ChessIconWhite => _model.ChessIconWhite;
        public Visibility BV { get; set; } = Visibility.Visible;
        public Visibility SVV { get; set; } = Visibility.Visible;
        public Visibility TBV { get; set; } = Visibility.Collapsed;

        public string Search
        {
            get { return GetValue<string>(); }
            set { SetValue(value, changedCallback: SearchPlayer); }
        }
        public int place { get; set; } = 1;
        public ObservableCollection<AdminPanelModel> Players { get; set; } = new ObservableCollection<AdminPanelModel>();

		public AdminPanelViewModel()
		{
			_model.PropertyChanged += (s, e) => RaisePropertiesChanged(e.PropertyName);
            SearchPlayer();
        }
        public void SearchPlayer()
        {
            var players = _model.GetAllUser().OrderByDescending(player => player.Rating);
            var nick = _model.GetAllUser();
            if (!string.IsNullOrWhiteSpace(Search))
            {
                nick = nick.Where(p => p.Nick.Contains(Search)).ToList();
                var itemsToCollapse = Players.Except(
                            nick.Select(nick => new AdminPanelModel(0, "", 0, Visibility.Visible, 0) { Nick = nick.Nick }),
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
                        item.Visibility = Visibility.Visible;
                    }
                }
                //if (personWithMaxAge.Nick.Contains(Search)) BV = Visibility.Visible;
                //else BV = Visibility.Collapsed;


                bool allCollapsed = Players.All(item => item.Visibility == Visibility.Collapsed);

                if (nick.Count == 0 && allCollapsed)
                {
                    SVV = Visibility.Collapsed;
                    TBV = Visibility.Visible;
                }
                else
                {
                    SVV = Visibility.Visible;
                    TBV = Visibility.Collapsed;
                }
            }
            else
            {
                if (Players.Count == 0)
                {
                    foreach (var i in players)
                    {
                            Players.Add(new AdminPanelModel(place++, i.Nick, i.Rating, Visibility.Visible, i.Iduser));
                    }
                }
                else
                {
                    BV = Visibility.Visible;
                    SVV = Visibility.Visible;
                    TBV = Visibility.Collapsed;
                    Players.ForEach(item => item.Visibility = Visibility.Visible);

                }

            }
        }
        public class MyItemComparer : IEqualityComparer<AdminPanelModel>
        {
            public bool Equals(AdminPanelModel x, AdminPanelModel y)
            {
                return x.Nick == y.Nick;
            }
            public int GetHashCode(AdminPanelModel obj)
            {
                return obj.Nick.GetHashCode();
            }
        }
        public DelegateCommand BackCommand => new(() => _model.IsBack());

    }
}
