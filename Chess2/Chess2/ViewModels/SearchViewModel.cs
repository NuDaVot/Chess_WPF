namespace Chess2.ViewModels
{
    public class SearchViewModel : BindableBase
    {
        private readonly PageService _pageService;
        public SearchViewModel(PageService pageService)
        {
            _pageService = pageService;
        }
        public DelegateCommand CancelCommand => new(() => _pageService.ChangePage(new Menu()));
    }
}
