﻿namespace ShowTweets.DataModel
{
    public class CommentWithTweetDto
    {
        public TweetDto Tweet { get; set; }
        public Comment Comment { get; set; }
    }
}