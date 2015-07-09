using System.Collections.Generic;
using System.Threading.Tasks;
using Ploeh.AutoFixture;
using ShowTweets.DataModel;

namespace ShowTweets.Services
{
    public class DesignTwitterFeedService : ITwitterFeedService
    {
        private readonly IFixture _fixture;

        public DesignTwitterFeedService()
        {
            _fixture = new Fixture();
        }

        public Task<IEnumerable<TweetDto>> GetTweetsAsync(string query)
        {
            var seeds = _fixture.CreateMany<TweetDto>(10);

            var taskCompletionSource = new TaskCompletionSource<IEnumerable<TweetDto>>();
            taskCompletionSource.SetResult(seeds);

            return taskCompletionSource.Task;
        }

        public Task<IEnumerable<TweetDto>> GetTweetsFor(IEnumerable<string> tweetsIds)
        {
            return null;
        }
    }
}