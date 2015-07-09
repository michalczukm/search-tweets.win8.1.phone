using LinqToTwitter;

namespace ShowTweets.Services
{
    public interface ITwitterCredentialStoreProvider
    {
        SingleUserInMemoryCredentialStore GetMemoryCredentialStore();
    }
}