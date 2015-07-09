using System.Collections.Generic;
using System.Threading.Tasks;
using ShowTweets.DataModel;

namespace ShowTweets.Services
{
    public interface ICommentsService
    {
        Task SaveCommentForTweet(string tweetId, string content);
        Task<IEnumerable<CommentWithTweetDto>> GetAllCommentsAsync();
    }
}
