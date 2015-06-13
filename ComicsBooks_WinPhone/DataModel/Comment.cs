using System;
using SQLite;

namespace ComicsBooks_WinPhone.DataModel
{
    public class Comment
    {
        public Comment()
        {
            CreationTime = DateTime.Now;
        }

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(200)]
        public string Content { get; set; }

        public DateTime CreationTime
        {
            get { return CreationTime; }
            private set { CreationTime = value; }
        }

        [MaxLength(100)]
        public string TweetId { get; set; }
    }
}