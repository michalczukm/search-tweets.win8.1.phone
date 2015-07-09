using System;
using System.Threading.Tasks;
using SQLite;

namespace ShowTweets.DataAccess
{
    public interface ITweetsDataContext : IDisposable
    {
        AsyncTableQuery<T> GetQuery<T>() where T : class, new();
        void AddEntity<T>(T item) where T : class;
        Task Init();
    }
}