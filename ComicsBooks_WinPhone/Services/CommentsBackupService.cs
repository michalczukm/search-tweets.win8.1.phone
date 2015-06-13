using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ComicsBooks_WinPhone.DataModel;
using Newtonsoft.Json;

namespace ComicsBooks_WinPhone.Services
{
    class CommentsBackupService : ICommentsBackupService
    {
        private readonly string _uri;

        public CommentsBackupService()
        {
            _uri = "http://localhost:1337";
        }

        public async Task Persist(Comment comment)
        {
            var dataString = JsonConvert.SerializeObject(comment);

            using (var client = new HttpClient())
            {
                var stringContent = new StringContent(dataString, Encoding.UTF8, "application/json");
                await client.PostAsync(_uri, stringContent);
            }
        }
    }
}