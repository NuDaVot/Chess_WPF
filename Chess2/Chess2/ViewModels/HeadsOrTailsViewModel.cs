

namespace Chess2.ViewModels
{
    public class HeadsOrTailsViewModel : BindableBase
    {
        private readonly PageService _pageService;
        public HeadsOrTailsViewModel(PageService pageService)
        {
            _pageService = pageService;
        }
    }
}
