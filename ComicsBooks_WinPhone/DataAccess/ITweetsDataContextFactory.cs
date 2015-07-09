using System.Threading.Tasks;

namespace ShowTweets.DataAccess
{
    public interface ITweetsDataContextFactory
    {
        Task<ITweetsDataContext> Create();
    }
}