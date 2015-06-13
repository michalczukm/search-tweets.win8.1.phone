using System;
using System.Windows.Input;
using ComicsBooks_WinPhone.DataModel;
using ComicsBooks_WinPhone.Navigation;
using ComicsBooks_WinPhone.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace ComicsBooks_WinPhone.ViewModel
{
    public class ItemViewModel : ViewModelBase
    {
        private readonly ICommentsService _commentsService;
        private readonly INavigationService _navigationService;
        private string _comment;
        private ICommand _saveTweetCommand;
        private TweetDto _tweet;
        private ICommand _clearTweetCommand;

        public ItemViewModel(ICommentsService commentsService, INavigationService navigationService)
        {
            _commentsService = commentsService;
            _navigationService = navigationService;
        }

        public string Text { get { return _tweet.Text; } }
        public Uri SourceUri { get { return _tweet.TweetUri; } }
        public DateTime CreatedAt { get { return _tweet.CreatedAt; } }
        public string UserName { get { return _tweet.UserName; } }
        public Uri UserProfileImageUri { get { return _tweet.UserProfileImageUri; } }

        public string Comment
        {
            get { return _comment; }
            set { Set(() => Comment, ref _comment, value); }
        }


        public ICommand SaveCommentCommand
        {
            get
            {
                return _saveTweetCommand
                    ?? (_saveTweetCommand = new RelayCommand(async () =>
                    {
                        await _commentsService.SaveCommentForTweet(_tweet.Id, Comment);
                        _navigationService.GoBack();
                    }));
            }
        }

        public ICommand ClearCommentCommand
        {
            get
            {
                return _clearTweetCommand
                    ?? (_clearTweetCommand = new RelayCommand(() =>
                    {
                        Comment = String.Empty;
                    }));
            }
        }

        public void Init(TweetDto tweetDto)
        {
            _tweet = tweetDto;
        }
    }
}