namespace Chess2.Model
{
    class ProfileModel : BindableBase
	{
		MainWindowModel _mainWindow;
        HistoryChessContext _historyChessContext;
        private readonly IMapper _mapper;
        public string CrossRed = "/Resources/Pictures/CrossRed.png";
        public string Cross = "/Resources/Pictures/Cross.png";
        public string ChessBoard = "/Resources/Pictures/ChessBoard.png";
		public string ChessIcon = "/Resources/Pictures/ChessIcon.png";
		public string JackdawRed = "/Resources/Pictures/JackdawRed.png";
		public string PercentRed = "/Resources/Pictures/PercentRed.png";
		public string JackdawGreen = "/Resources/Pictures/JackdawGreen.png";
		public string Jackdaw = "/Resources/Pictures/Jackdaw.png";
		public string BlackRect = "/Resources/Pictures/BR.png";
		public string WhiteRect = "/Resources/Pictures/WR.png";
		public string FastMode = "/Resources/Pictures/FastMode.png";
        public string ClassicMode = "/Resources/Pictures/ClassicMode.png";
        public List<DBParty> GetParty()
        {
            List<DBParty> dbProduct = new();
            try
            {
                _historyChessContext.Users.ToList();
                dbProduct = _mapper.Map<List<DBParty>>(_historyChessContext.Parties.ToList());
            }
            catch { }
            return dbProduct.ToList();
        }
        public void IsBack()
        {
            _mainWindow.Navipage("Menu.xaml");
        }
        public ProfileModel()
		{
			_mainWindow = MainWindowViewModel._metod;
            _historyChessContext = new HistoryChessContext();
            _mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Party, DBParty>();
            }).CreateMapper();
        }
		
	}
}
