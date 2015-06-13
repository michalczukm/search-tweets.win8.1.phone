using System.Threading.Tasks;

namespace ComicsBooks_WinPhone.DAL
{
    public interface ITweetsDataContextFactory
    {
        Task<ITweetsDataContext> Create();
    }
}