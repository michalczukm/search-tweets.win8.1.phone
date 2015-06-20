using System.Threading.Tasks;

namespace ComicsBooks_WinPhone.DataAccess
{
    public class DesignTweetsDataContextFactory : ITweetsDataContextFactory
    {
        public Task<ITweetsDataContext> Create()
        {
            return null;
        }
    }
}