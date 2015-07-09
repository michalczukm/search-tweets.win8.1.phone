using System.Threading.Tasks;

namespace ShowTweets.DataAccess
{
    public class DesignTweetsDataContextFactory : ITweetsDataContextFactory
    {
        public Task<ITweetsDataContext> Create()
        {
            return null;
        }
    }
}