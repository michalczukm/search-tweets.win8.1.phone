using System;
using System.Threading.Tasks;
using SQLite;

namespace ComicsBooks_WinPhone.DAL
{
    public interface ITweetsDataContext : IDisposable
    {
        AsyncTableQuery<T> GetQuery<T>() where T : class, new();
        void AddEntity<T>(T item) where T : class;
        Task Init();
    }
}