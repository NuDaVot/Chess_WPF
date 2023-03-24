
namespace Chess2.ViewModels
{
    public class SignInViewModel : BindableBase
    {
		private readonly PageService _pageService;
		public SignInViewModel(PageService pageService)
		{
			_pageService = pageService;
		}
		public DelegateCommand AuthorizationCommand => new(() => _pageService.ChangePage(new Menu()));
        public DelegateCommand CanselCommand => new(() => _pageService.ChangePage(new MenuA()));
    }
}
