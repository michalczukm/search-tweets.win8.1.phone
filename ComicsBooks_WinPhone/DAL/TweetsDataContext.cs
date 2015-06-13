
using System;
using System.IO;
using System.Threading.Tasks;
using Windows.Storage;
using ComicsBooks_WinPhone.DataModel;
using SQLite;

namespace ComicsBooks_WinPhone.DAL
{
    public class TweetsDataContext : ITweetsDataContext
    {
        private bool _isInitialized;

        public TweetsDataContext()
        {
            if (!_isInitialized)
            {
                throw new Exception("DB not initialized, use `Init` method");
            }
        }

        public AsyncTableQuery<T> GetQuery<T>() where T : class, new()
        {
            var connection = GetConnection();
            return connection.Table<T>();
        }

        public async void AddEntity<T>(T item) where T : class
        {
            await GetConnection().InsertAsync(item);
        }

        public async Task Init()
        {
            SQLiteAsyncConnection connection = GetConnection();
            await connection.CreateTableAsync<Comment>();
            _isInitialized = true;
        }

        private SQLiteAsyncConnection GetConnection()
        {
            return new SQLiteAsyncConnection(Path.Combine(ApplicationData.Current.LocalFolder.Path, "tweets.db"));
        }

        public void Dispose()
        {
        }
    }
}