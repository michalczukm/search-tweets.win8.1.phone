using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;
using ComicsBooks_WinPhone.DataModel;
using ComicsBooks_WinPhone.Navigation;
using ComicsBooks_WinPhone.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace ComicsBooks_WinPhone.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private readonly ITwitterFeedService _twitterFeedService;
        private readonly ICommentsService _commentsService;
        private readonly INavigationService _navigationService;
        private ObservableCollection<TweetDto> _tweets;
        private RelayCommand<ItemClickEventArgs> _showTweetCommand;
        private ObservableCollection<CommentWithTweetDto> _comments;

        public MainViewModel(ITwitterFeedService twitterFeedService, INavigationService navigationService, ICommentsService commentsService)
        {
            _twitterFeedService = twitterFeedService;
            _navigationService = navigationService;
            _commentsService = commentsService;

            Tweets = new ObservableCollection<TweetDto>();
        }

        public ObservableCollection<TweetDto> Tweets
        {
            get { return _tweets; }
            set { Set(() => Tweets, ref _tweets, value); }
        }

        public ObservableCollection<CommentWithTweetDto> Comments
        {
            get { return _comments; }
            set { Set(() => Comments, ref _comments, value); }
        }

        public RelayCommand<ItemClickEventArgs> ShowTweetCommand
        {
            get
            {
                return _showTweetCommand
                    ?? (_showTweetCommand = new RelayCommand<ItemClickEventArgs>((eventArgs) =>
                    {
                        var tweet = ((TweetDto)eventArgs.ClickedItem);

                        _navigationService.Navigate(typeof(ItemPage), tweet);
                    }));
            }
        }

        public async Task Init()
        {
            await Refetch();
        }

        private async Task Refetch()
        {
            var tweetDtos = await _twitterFeedService.GetTweetsAsync();
            var comments = await _commentsService.GetAllComments();
            Tweets = new ObservableCollection<TweetDto>(tweetDtos);
            Comments = new ObservableCollection<CommentWithTweetDto>(comments);
        }
    }
}