using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Windows.Web.Http;
using ComicsBooks_WinPhone.DataModel;
using ComicsBooks_WinPhone.DAL;
using HttpResponseMessage = System.Net.Http.HttpResponseMessage;
using UnicodeEncoding = Windows.Storage.Streams.UnicodeEncoding;

namespace ComicsBooks_WinPhone.Services
{
    public class CommentsService : ICommentsService
    {
        private readonly ICommentsBackupService _backupService;
        private readonly ITweetsDataContextFactory _contextFactory;
        private readonly ITwitterFeedService _twitterFeedService;

        public CommentsService(ITweetsDataContextFactory contextFactory, ITwitterFeedService twitterFeedService, ICommentsBackupService backupService)
        {
            _contextFactory = contextFactory;
            _twitterFeedService = twitterFeedService;
            _backupService = backupService;
        }

        public async Task<IEnumerable<CommentWithTweetDto>> GetAllCommentsAsync()
        {
            using (var context = await _contextFactory.Create())
            {
                List<Comment> comments = await context.GetQuery<Comment>().ToListAsync();

                List<string> tweetsIds = comments.Select(comment => comment.TweetId).ToList();
                IEnumerable<TweetDto> tweets = await _twitterFeedService.GetTweetsFor(tweetsIds);
                IEnumerable<Comment> commentsEnumerable = comments;

                var result = commentsEnumerable
                    .Join(tweets, comment => comment.TweetId, tweet => tweet.Id,
                        (comment, tweet) => new CommentWithTweetDto
                        {
                            Comment = comment,
                            Tweet = tweet
                        });

                return result;
            }

        }

        public async Task SaveCommentForTweet(string tweetId, string content)
        {
            using (var context = await _contextFactory.Create())
            {
                var comment = new Comment
                {
                    Content = content,
                    TweetId = tweetId,
                    CreationTime = DateTime.Now.Date
                };

                context.AddEntity(comment);

                await _backupService.Persist(comment);
            }
        }
    }
}