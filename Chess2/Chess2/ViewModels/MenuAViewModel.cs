namespace Chess2.ViewModels
{
    public class MenuAViewModel : BindableBase
    {
		private readonly PageService _pageService;
		public MenuAViewModel(PageService pageService)
		{
			_pageService = pageService;
		}
		public DelegateCommand SignInCommand => new(() => _pageService.ChangePage(new SignIn()));
		public DelegateCommand SignUpCommand => new(() => _pageService.ChangePage(new SignUp()));
        public DelegateCommand LeaderboardCommand => new(() => _pageService.ChangePage(new Leaderboard()));
    }
}
