using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using LinqToTwitter;
using ShowTweets.DataModel;
using ShowTweets.Extensions;

namespace ShowTweets.Services
{
    public class TwitterFeedService : ITwitterFeedService
    {
        private readonly ITwitterCredentialStoreProvider _credentialStoreProvider;

        public TwitterFeedService(ITwitterCredentialStoreProvider credentialStoreProvider)
        {
            _credentialStoreProvider = credentialStoreProvider;
        }

        public async Task<IEnumerable<TweetDto>> GetTweetsAsync(string query)
        {
            using (var twitterContext = CreateContext())
            {
                var queryString = String.Format("\"{0}\"", query);
                Search searchResponse =
                await
                    twitterContext.Search
                    .Where(search => search.Type == SearchType.Search && search.Query == queryString)
                        .SingleOrDefaultAsync();

                if (searchResponse != null && searchResponse.Statuses != null)
                {
                    return searchResponse.Statuses.Select(BuildTweetDto);
                }

                return Enumerable.Empty<TweetDto>();
            }
        }

        public async Task<IEnumerable<TweetDto>> GetTweetsFor(IEnumerable<string> tweetsIds)
        {
            var tweetsIdsList = tweetsIds.Select(s => Convert.ToUInt64(s)).Materialize();

            if (tweetsIdsList.IsEmpty())
            {
                return Enumerable.Empty<TweetDto>();
            }

            using (var twitterContext = CreateContext())
            {
                var results = new List<TweetDto>();
                foreach (var tweetsId in tweetsIdsList)
                {
                    var id = tweetsId;
                    var tweet = await
                    twitterContext.Status
                        .Where(status => status.Type == StatusType.Show && status.ID == id).FirstOrDefaultAsync();
                    if (tweet != null)
                    {
                        results.Add(BuildTweetDto(tweet));
                    }
                }

                return results;
            }
        }

        private static TweetDto BuildTweetDto(Status tweet)
        {
            return new TweetDto
            {
                Id = tweet.StatusID.ToString(CultureInfo.InvariantCulture),
                TweetUri = new Uri(String.Format("https://twitter.com/statuses/ID/{0}", tweet.ID)),
                Text = tweet.Text,
                UserName = tweet.User.Name,
                CreatedAt = tweet.CreatedAt,
                UserProfileImageUri = new Uri(tweet.User.ProfileImageUrl)
            };
        }

        private TwitterContext CreateContext()
        {
            var credentialStore = _credentialStoreProvider.GetMemoryCredentialStore();

            var auth = new SingleUserAuthorizer
            {
                CredentialStore = credentialStore
            };

            return new TwitterContext(auth);
        }
    }
}