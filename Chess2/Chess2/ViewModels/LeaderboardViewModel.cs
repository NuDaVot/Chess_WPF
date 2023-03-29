

namespace Chess2.ViewModels
{
    public class LeaderboardViewModel : BindableBase
    {
        private readonly PageService _pageService;
        public LeaderboardViewModel(PageService pageService)
        {
            _pageService = pageService;
        }
    }
}
