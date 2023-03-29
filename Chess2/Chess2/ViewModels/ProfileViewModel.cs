namespace Chess2.ViewModels
{
    public class ProfileViewModel : BindableBase
    {
        private readonly PageService _pageService;
        public ProfileViewModel(PageService pageService)
        {
            _pageService = pageService;
        }
    }
}
