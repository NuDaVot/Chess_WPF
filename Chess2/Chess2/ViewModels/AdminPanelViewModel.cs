using Chess2.Data;
using System.Linq;
using System.Windows.Media;

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
        public Visibility SVV { get; set; } = Visibility.Visible;
        public Visibility TBV { get; set; } = Visibility.Collapsed;

        public string Search
        {
            get { return GetValue<string>(); }
            set { SetValue(value, changedCallback: SearchPlayer); }
        }
        public int place { get; set; } = 1;
        public ObservableCollection<DbUser> Players { get; set; } 

		public AdminPanelViewModel()
		{
			_model.PropertyChanged += (s, e) => RaisePropertiesChanged(e.PropertyName);
            SearchPlayer();
        }
        async public void SearchPlayer()
        {
            var player = await _model.GetUsers();
            var nick = await _model.GetUsers();
            
            if (!string.IsNullOrWhiteSpace(Search))
            {
                nick = nick.Where(p => p.Nick.Contains(Search)).ToList();
                var itemsToCollapse = Players.Except(
                            nick.Select(nick => new DbUser() { Nick = nick.Nick }),
                            new MyItemComparer());
                itemsToCollapse.ForEach(item => item.Visibility = Visibility.Collapsed);
                foreach (var item in Players)
                {
                    if (nick.Any(item2 => item2.Nick == item.Nick))
                    {
                        item.Visibility = Visibility.Visible;
                    }
                }
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
                if (Players == null)
                {
                    Players = new ObservableCollection<DbUser>(player);
                    foreach (var i in Players)
                    {
                        var party = _model.GetAllParty();
                        party = party.Where(p => p.WhiteUser == i.Iduser || p.BlackUser == i.Iduser).ToList();
                        int win = 0, lose = 0, draw = 0;
                        foreach (var party1 in party)
                        {
                            if ((bool)party1.Result && party1.WhiteUser == i.Iduser)
                            {
                                win++;
                            }
                            else if (!(bool)party1.Result && party1.WhiteUser == i.Iduser)
                                lose++;
                            else if (!(bool)party1.Result && party1.BlackUser == i.Iduser)
                                win++;
                            else if ((bool)party1.Result && party1.BlackUser == i.Iduser)
                                lose++;
                            else draw++;
                        }
                        i.Place = place;
                        place++;
                        i.Visibility = Visibility.Visible;
                        i.Partys = party.Count;
                        i.Wins = win; i.Losses = lose; i.Draws = draw;
                        if ((bool)i.Status)
                            i.Ban = "Бан";
                        else i.Ban = "Разбан";

                    }
                }
                else
                {
                    SVV = Visibility.Visible;
                    TBV = Visibility.Collapsed;
                    Players.ForEach(item => item.Visibility = Visibility.Visible);
                }
                
            }
            
        }
        
        public class MyItemComparer : IEqualityComparer<DbUser>
        {
            public bool Equals(DbUser x, DbUser y)
            {
                return x.Nick == y.Nick;
            }
            public int GetHashCode(DbUser obj)
            {
                return obj.Nick.GetHashCode();
            }
        }
        public DelegateCommand BackCommand => new(() => _model.IsBack());

    }
}
