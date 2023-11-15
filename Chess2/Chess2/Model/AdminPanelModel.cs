using Chess2.Data;
using System.Windows.Media;
using System.Windows;
using System.ComponentModel;
using AutoMapper;

namespace Chess2.Model
{
    public class AdminPanelModel : BindableBase
    {
		MainWindowModel _mainWindow;
		HistoryChessContext _historyChessContext;
        private readonly IMapper _mapper;

        public string Jackdaw = "/Resources/Pictures/Jackdaw.png";
		public string Percent = "/Resources/Pictures/Percent.png";
		public string Cross = "/Resources/Pictures/Cross.png";
		public string ChessBoard = "/Resources/Pictures/ChessBoard.png";
		public string FirstPlace = "/Resources/Pictures/FirstPlace.png";
		public string ChessIconWhite = "/Resources/Pictures/ChessIconWhite.png";
		public List<User> GetAllUser() => _historyChessContext.Users.Where(i => i.Role == true).ToList();
        public async Task SaveChangesAsync() => await _historyChessContext.SaveChangesAsync();
        public List<Party> GetAllParty() => _historyChessContext.Parties.ToList();
        public async Task<List<DbUser>> GetUsers()
        {
            List<DbUser> dbProduct = new();
            try
            {
                dbProduct = _mapper.Map<List<DbUser>>(await _historyChessContext.Users.Where(i => i.Role == true).ToListAsync());
            }
            catch { }
            return dbProduct.OrderByDescending(player => player.Rating).ToList(); 
        }
        public AdminPanelModel()
		{
			_mainWindow = MainWindowViewModel._metod;
			_historyChessContext = new HistoryChessContext();

            _mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, DbUser>();
            }).CreateMapper();

        }
		public void IsBack()
		{
			_mainWindow.Navipage("SignIn.xaml");
		}
        public void IsProfile()
        {
            _mainWindow.Navipage("CheckProfile.xaml");
        }

    }
}
