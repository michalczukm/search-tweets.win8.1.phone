using LinqToTwitter;

namespace ComicsBooks_WinPhone.Services
{
    public interface ITwitterCredentialStoreProvider
    {
        SingleUserInMemoryCredentialStore GetMemoryCredentialStore();
    }
}