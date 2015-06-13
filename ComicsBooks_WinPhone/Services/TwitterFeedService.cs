using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using ComicsBooks_WinPhone.DataModel;
using LinqToTwitter;

namespace ComicsBooks_WinPhone.Services
{
    public class TwitterFeedService : ITwitterFeedService
    {
        public async Task<IEnumerable<TweetDto>> GetTweetsAsync()
        {
            var auth = new SingleUserAuthorizer
            {
                CredentialStore = new SingleUserInMemoryCredentialStore
                {
                    
                }
            };

            var twitterContext = new TwitterContext(auth);

            Search searchResponse =
                await
                    twitterContext.Search
                    .Where(search => search.Type == SearchType.Search && search.Query == "\"LINQ to Twitter\"")
                        .SingleOrDefaultAsync();

            if (searchResponse != null && searchResponse.Statuses != null)
            {
                return searchResponse.Statuses.Select(tweet => new TweetDto
                {
                    Id = tweet.StatusID.ToString(CultureInfo.InvariantCulture),
                    TweetUri = new Uri(String.Format("https://twitter.com/statuses/ID/{0}", tweet.StatusID)),
                    Text = tweet.Text,
                    UserName = tweet.User.Name,
                    CreatedAt = tweet.CreatedAt,
                    UserProfileImageUri = new Uri(tweet.User.ProfileImageUrl)
                });
            }

            return Enumerable.Empty<TweetDto>();
        }
    }
}