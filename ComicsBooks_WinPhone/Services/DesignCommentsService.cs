using System.Collections.Generic;
using System.Threading.Tasks;
using ComicsBooks_WinPhone.DataModel;
using Ploeh.AutoFixture;

namespace ComicsBooks_WinPhone.Services
{
    public class DesignCommentsService : ICommentsService
    {
        private readonly IFixture _fixture;

        public DesignCommentsService()
        {
            _fixture = new Fixture();
        }

        public Task SaveCommentForTweet(string tweetId, string content)
        {
            return null;
        }

        public Task<IEnumerable<CommentWithTweetDto>> GetAllCommentsAsync()
        {
            var seeds = _fixture.CreateMany<CommentWithTweetDto>(10);

            var taskCompletionSource = new TaskCompletionSource<IEnumerable<CommentWithTweetDto>>();
            taskCompletionSource.SetResult(seeds);

            return taskCompletionSource.Task;
        }
    }
}