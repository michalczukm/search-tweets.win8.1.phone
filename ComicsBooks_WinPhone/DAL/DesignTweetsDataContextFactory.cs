using System.Threading.Tasks;

namespace ComicsBooks_WinPhone.DAL
{
    public class DesignTweetsDataContextFactory : ITweetsDataContextFactory
    {
        public Task<ITweetsDataContext> Create()
        {
            return null;
        }
    }
}