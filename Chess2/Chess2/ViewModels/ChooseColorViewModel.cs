
namespace Chess2.ViewModels
{
    public class ChooseColorViewModel : BindableBase
    {
        private readonly PageService _pageService;
        public ChooseColorViewModel(PageService pageService)
        {
            _pageService = pageService;
        }
    }
}
