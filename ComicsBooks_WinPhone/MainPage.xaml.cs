using System;
using Windows.Graphics.Display;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using ComicsBooks_WinPhone.Common;
using ComicsBooks_WinPhone.ViewModel;

namespace ComicsBooks_WinPhone
{
    public sealed partial class MainPage : Page
    {
        private readonly NavigationHelper _navigationHelper;

        public MainPage()
        {
            InitializeComponent();

            // Hub is only supported in Portrait orientation
            DisplayInformation.AutoRotationPreferences = DisplayOrientations.Portrait;

            NavigationCacheMode = NavigationCacheMode.Required;

            _navigationHelper = new NavigationHelper(this);
            _navigationHelper.LoadState += NavigationHelper_LoadState;
            _navigationHelper.SaveState += NavigationHelper_SaveState;
        }

        private async void NavigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
            var viewModel = (MainViewModel)DataContext;
            await viewModel.Init();
        }

        /// <summary>
        /// Preserves state associated with this page in case the application is suspended or the
        /// page is discarded from the navigation cache.  Values must conform to the serialization
        /// requirements of <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="sender">The source of the event; typically <see cref="NavigationHelper"/></param>
        /// <param name="e">Event data that provides an empty dictionary to be populated with
        /// serializable state.</param>
        private void NavigationHelper_SaveState(object sender, SaveStateEventArgs e)
        {
            // TODO: Save the unique state of the page here.
        }

        private void ItemView_ItemClick(object sender, ItemClickEventArgs e)
        {
//            // Navigate to the appropriate destination page, configuring the new page
//            // by passing required information as a navigation parameter
//            var itemId = ((SampleDataItem)e.ClickedItem).UniqueId;
//            if (!Frame.Navigate(typeof(ItemPage), itemId))
//            {
//                throw new Exception(this.resourceLoader.GetString("NavigationFailedExceptionMessage"));
//            }
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
