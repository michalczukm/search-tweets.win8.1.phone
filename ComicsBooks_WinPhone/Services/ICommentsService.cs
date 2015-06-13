using System.Threading.Tasks;
using ComicsBooks_WinPhone.DataModel;
using ComicsBooks_WinPhone.DAL;

namespace ComicsBooks_WinPhone.Services
{
    public interface ICommentsService
    {
        Task SaveCommentForTweet(string tweetId, string content);
    }

    class CommentsService : ICommentsService
    {
        private readonly ITweetsDataContextFactory _contextFactory;

        public CommentsService(ITweetsDataContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task SaveCommentForTweet(string tweetId, string content)
        {
            using (var context = await _contextFactory.Create())
            {
                var comment = new Comment
                {
                    Content = content,
                    TweetId = tweetId
                };

                context.AddEntity(comment);
            }
        }
    }
}