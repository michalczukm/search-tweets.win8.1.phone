using System.Collections.Generic;
using System.Threading.Tasks;
using ComicsBooks_WinPhone.DataModel;

namespace ComicsBooks_WinPhone.Services
{
    public interface ITwitterFeedService
    {
        Task<IEnumerable<TweetDto>> GetTweetsAsync();
    }
}