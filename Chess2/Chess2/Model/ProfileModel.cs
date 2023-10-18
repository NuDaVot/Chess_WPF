using Paragraph = iText.Layout.Element.Paragraph;
using Table = iText.Layout.Element.Table;
using iText.IO.Font;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Properties;
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
        public string Percent = "/Resources/Pictures/Percent.png";
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
        public async Task GetReport()
        {
            PdfWriter writer = new($"Отчет.pdf");
            PdfDocument pdf = new(writer);
            Document document = new(pdf);

            PdfFont comic = PdfFontFactory.CreateFont(@"C:\Windows\Fonts\TIMES.ttf", PdfEncodings.IDENTITY_H, PdfFontFactory.EmbeddingStrategy.PREFER_NOT_EMBEDDED);

            var content = new Paragraph($"Отчет по профилю")
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT)
                .SetFont(comic)
                .SetFontSize(12);

            document.Add(content);

            content = new Paragraph($"Дата: {DateOnly.FromDateTime(DateTime.Now).ToString("D")}")
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                .SetFont(comic)
                .SetFontSize(16);

            document.Add(content);

            content = new Paragraph() // напиши сюда данные для вывода
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT)
                .SetFont(comic)
                .SetFontSize(16);

            document.Add(content);

            document.Close();

            await Task.CompletedTask;
        }
    }
}
