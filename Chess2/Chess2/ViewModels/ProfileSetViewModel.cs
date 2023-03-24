namespace Chess2.ViewModels
{
   public class ProfileSetViewModel : BindableBase
   {
        private readonly PageService _pageService;
        public ProfileSetViewModel(PageService pageService)
        {
            _pageService = pageService;
        }
    }
}
