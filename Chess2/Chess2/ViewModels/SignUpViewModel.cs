namespace Chess2.ViewModels
{
    public class SignUpViewModel : BindableBase
    {
        private readonly PageService _pageService;
        public SignUpViewModel(PageService pageService)
        {
            _pageService = pageService;
        }
        public DelegateCommand RegistrCommand => new(() => _pageService.ChangePage(new Menu()));
    }
}
