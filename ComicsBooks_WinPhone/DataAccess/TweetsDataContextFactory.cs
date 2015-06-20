using System.Threading.Tasks;

namespace ComicsBooks_WinPhone.DataAccess
{
    public class TweetsDataContextFactory : ITweetsDataContextFactory
    {
        public async Task<ITweetsDataContext> Create()
        {
            var tweetsDataContext = new TweetsDataContext();
            await tweetsDataContext.Init();

            return tweetsDataContext;
        }
    }
}