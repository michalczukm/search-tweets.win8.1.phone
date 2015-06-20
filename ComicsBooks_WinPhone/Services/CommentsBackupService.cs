using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ComicsBooks_WinPhone.DataModel;
using Newtonsoft.Json;
using PortableRest;

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
            var client = new RestClient{ BaseUrl = _uri };

            var request = new RestRequest("/", HttpMethod.Post, ContentTypes.Json);
            request.AddParameter("item", JsonConvert.SerializeObject(comment));

            await client.ExecuteAsync<Comment>(request, CancellationToken.None);
        }
    }
}