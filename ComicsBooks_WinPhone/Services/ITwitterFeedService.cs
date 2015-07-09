using System.Collections.Generic;
using System.Threading.Tasks;
using ShowTweets.DataModel;

namespace ShowTweets.Services
{
    public interface ITwitterFeedService
    {
        Task<IEnumerable<TweetDto>> GetTweetsAsync(string query);
        Task<IEnumerable<TweetDto>> GetTweetsFor(IEnumerable<string> tweetsIds);
    }
}