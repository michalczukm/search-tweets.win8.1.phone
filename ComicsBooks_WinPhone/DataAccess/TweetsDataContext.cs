using System;
using System.IO;
using System.Threading.Tasks;
using Windows.Storage;
using ShowTweets.DataModel;
using SQLite;

namespace ShowTweets.DataAccess
{
    public class TweetsDataContext : ITweetsDataContext
    {
        private bool _isInitialized;

        public AsyncTableQuery<T> GetQuery<T>() where T : class, new()
        {
            CanExecute();

            var connection = GetConnection();
            return connection.Table<T>();
        }

        public async void AddEntity<T>(T item) where T : class
        {
            CanExecute();

            await GetConnection().InsertAsync(item);
        }

        public async Task Init()
        {
            SQLiteAsyncConnection connection = GetConnection();
            await connection.CreateTableAsync<Comment>();
            _isInitialized = true;
        }

        private bool CanExecute()
        {
            if (!_isInitialized)
            {
                throw new Exception("DB not initialized, use `Init` method");
            }

            return true;
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