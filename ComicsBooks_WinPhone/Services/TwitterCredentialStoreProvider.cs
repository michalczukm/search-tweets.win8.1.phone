using LinqToTwitter;

namespace ComicsBooks_WinPhone.Services
{
    public class TwitterCredentialStoreProvider : ITwitterCredentialStoreProvider
    {
        public SingleUserInMemoryCredentialStore GetMemoryCredentialStore()
        {
            return new SingleUserInMemoryCredentialStore
            {
                ConsumerKey = "***REMOVED***",
                ConsumerSecret = "***REMOVED***",
                AccessToken = "***REMOVED***",
                AccessTokenSecret = "***REMOVED***"
            };
        }
    }
}