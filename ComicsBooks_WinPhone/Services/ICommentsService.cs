using System.Collections.Generic;
using System.Threading.Tasks;
using ComicsBooks_WinPhone.DataModel;

namespace ComicsBooks_WinPhone.Services
{
    public interface ICommentsService
    {
        Task SaveCommentForTweet(string tweetId, string content);
        Task<IEnumerable<CommentWithTweetDto>> GetAllComments();
    }
}
