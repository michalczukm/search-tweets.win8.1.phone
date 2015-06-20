using System.Threading.Tasks;

namespace ComicsBooks_WinPhone.DataAccess
{
    public interface ITweetsDataContextFactory
    {
        Task<ITweetsDataContext> Create();
    }
}