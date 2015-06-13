using System.Collections.Generic;
using System.Threading.Tasks;
using ComicsBooks_WinPhone.DataModel;
using Ploeh.AutoFixture;

namespace ComicsBooks_WinPhone.Services
{
    public class DesignTwitterFeedService : ITwitterFeedService
    {
        private readonly IFixture _fixture;

        public DesignTwitterFeedService()
        {
            _fixture = new Fixture();
        }

        public Task<IEnumerable<TweetDto>> GetTweetsAsync()
        {
            var seeds = _fixture.CreateMany<TweetDto>(10);

            var taskCompletionSource = new TaskCompletionSource<IEnumerable<TweetDto>>();
            taskCompletionSource.SetResult(seeds);

            return taskCompletionSource.Task;
        }
    }
}