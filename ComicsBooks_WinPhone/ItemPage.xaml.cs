using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using ComicsBooks_WinPhone.Common;
using ComicsBooks_WinPhone.DataModel;
using ComicsBooks_WinPhone.ViewModel;

namespace ComicsBooks_WinPhone
{
    public sealed partial class ItemPage : Page
    {
        private readonly NavigationHelper _navigationHelper;

        public ItemPage()
        {
            InitializeComponent();

            _navigationHelper = new NavigationHelper(this);
            _navigationHelper.LoadState += NavigationHelper_LoadState;
        } 

        private void NavigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
            var viewModel = (ItemViewModel)DataContext;
            var navigationParameter = (TweetDto)e.NavigationParameter;

            viewModel.Init(navigationParameter);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            _navigationHelper.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            _navigationHelper.OnNavigatedFrom(e);
        }
    }
}
