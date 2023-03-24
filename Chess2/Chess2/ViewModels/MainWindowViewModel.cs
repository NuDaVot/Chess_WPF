
namespace Chess2.ViewModels
{
    public class MainWindowViewModel: BindableBase
    {
		private readonly PageService _pageService;
		public Page PageSource { get; set; }
		public ImageBrush Background { get; set; }
		public MainWindowViewModel(PageService pageService)
		{
			_pageService = pageService;

			_pageService.onPageChanged += (page) => PageSource = page;

			_pageService.ChangePage(new MenuA());
            this.Background = new ImageBrush(new BitmapImage(new Uri(@"pack://application:,,,/Resources/Pictures/Background.png")));

        }
	}
}
