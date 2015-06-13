using System;

namespace ComicsBooks_WinPhone.DataModel
{
    public class TweetDto
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public Uri TweetUri { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UserName { get; set; }
        public Uri UserProfileImageUri { get; set; }
    }
}