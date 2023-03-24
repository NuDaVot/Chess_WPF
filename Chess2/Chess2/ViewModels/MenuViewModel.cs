namespace Chess2.ViewModels
{
    public class MenuViewModel : BindableBase
    {
		private readonly PageService _pageService;
		public MenuViewModel(PageService pageService)
		{
			_pageService = pageService;
		}
		public DelegateCommand SearchCommand => new(() => _pageService.ChangePage(new Search()));
		
	}
}
