using System;
using SQLite;

namespace ShowTweets.DataModel
{
    public class Comment
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(200)]
        public string Content { get; set; }

        public DateTime CreationTime { get; set; }

        [MaxLength(100)]
        public string TweetId { get; set; }
    }
}