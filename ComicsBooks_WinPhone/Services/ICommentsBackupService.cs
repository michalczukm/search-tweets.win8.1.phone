using System.Threading.Tasks;
using ComicsBooks_WinPhone.DataModel;

namespace ComicsBooks_WinPhone.Services
{
    public interface ICommentsBackupService
    {
        Task Persist(Comment comment);
    }
}