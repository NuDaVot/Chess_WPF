using Paragraph = iText.Layout.Element.Paragraph;
using Table = iText.Layout.Element.Table;
using iText.IO.Font;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Properties;
using Microsoft.Win32;

namespace Chess2.Model
{
    public class LeaderboardModel : BindableBase
	{
		MainWindowModel _mainWindow;
        HistoryChessContext _historyChessContext;


        public static bool MenuAOrMenu;
		public string Ramka = "/Resources/Pictures/Ramka.png";
        public string King = "/Resources/Pictures/King.png";
        public string Nick { get; set; }
        public int Place { get; set; }
        public int Id { get; set; }
        public int? Rating { get; set; }
        public Visibility Visibility { get; set; }
        public List<User> GetAllUser() => _historyChessContext.Users.Where(i => i.Status == true && i.Role == true).ToList();

        public LeaderboardModel(int place, string nick, int? rating, Visibility visibility, int id)
		{
			_mainWindow = MainWindowViewModel._metod;
            _historyChessContext = new HistoryChessContext();
            
            Place = place;
            Nick = nick;
            Rating = rating;
            Visibility = visibility;
            Id = id;
        }
        public void IsCancel()
		{
			if (MenuAOrMenu)
                _mainWindow.Navipage("MenuA.xaml");
            else _mainWindow.Navipage("Menu.xaml");

		}


        public async Task GetReport(IOrderedEnumerable<User> players)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "PDF files (*.pdf)|*.pdf",
                Title = "Создание отчета таблицы лидеров"
            };
            PdfFont comic = PdfFontFactory.CreateFont(@"Resources\Fonts\Oswald-Bold.ttf", PdfEncodings.IDENTITY_H, PdfFontFactory.EmbeddingStrategy.PREFER_NOT_EMBEDDED);
            if (saveFileDialog.ShowDialog() == true)
            {
                string outputPath = saveFileDialog.FileName;
                using (var writer = new PdfWriter(outputPath))
                {
                    using (var pdf = new PdfDocument(writer))
                    {
                        var document = new Document(pdf);
                        var content = new Paragraph("Отчет таблицы лидеров")
                            .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                            .SetFont(comic)
                            .SetFontSize(16);

                        document.Add(content);

                        content = new Paragraph($"Дата: {DateOnly.FromDateTime(DateTime.Now).ToString("D")}")
                            .SetTextAlignment(iText.Layout.Properties.TextAlignment.RIGHT)
                            .SetFont(comic)
                            .SetFontSize(16);

                        document.Add(content);
                        var table = new Table(3)
                            .SetWidth(UnitValue.CreatePercentValue(100))
                            .SetHeight(UnitValue.CreatePercentValue(100))
                            .SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER);

                        table.AddHeaderCell(new Paragraph("Место")
                            .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                            .SetFont(comic)
                            .SetFontSize(14));

                        table.AddHeaderCell(new Paragraph("Ник")
                            .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                            .SetFont(comic)
                            .SetFontSize(14));

                        table.AddHeaderCell(new Paragraph("Рейтинг")
                            .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                            .SetFont(comic)
                            .SetFontSize(14));
                        int place = 1;
                        foreach(var i in players)
                        {
                            table.AddCell(new Paragraph((place).ToString())
                               .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                               .SetFont(comic)
                               .SetFontSize(14));

                            table.AddCell(new Paragraph(i.Nick)
                               .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                               .SetFont(comic)
                               .SetFontSize(14));

                            table.AddCell(new Paragraph(i.Rating.ToString())
                                .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                                .SetFont(comic)
                                .SetFontSize(14));
                            place++;

                        }
                        document.Add(table);
                        document.Close();
                        await Task.CompletedTask;
                    }
                }
            }
        }

    }
}
