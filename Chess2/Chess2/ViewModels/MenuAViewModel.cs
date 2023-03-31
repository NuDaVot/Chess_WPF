namespace Chess2.ViewModels
{
    public class MenuAViewModel : BindableBase
    {
		readonly MenuAModel _model = new MenuAModel();
		public MenuAViewModel()
		{
		}
		//public DelegateCommand SignInCommand => new(() => _pageService.ChangePage(new SignIn()));
		//public DelegateCommand SignUpCommand => new(() => _pageService.ChangePage(new SignUp()));
  //      public DelegateCommand LeaderboardCommand => new(() => _pageService.ChangePage(new Leaderboard()));
    }
}
