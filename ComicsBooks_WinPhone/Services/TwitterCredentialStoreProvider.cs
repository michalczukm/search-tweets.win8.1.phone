using LinqToTwitter;

namespace ShowTweets.Services
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