using System;
using System.Collections.Generic;

namespace ElasticTweets.Library.Data
{
    public sealed class Tweet
    {
        public Contributor[] contributors { get; set; }
        public Coordinates coordinates { get; set; }
        public string created_at { get; set; }
        public UserIdentifier current_user_retweet { get; set; }
        public Entities entities { get; set;  } 
        public bool? favorited { get; set; }
        public Int64 id { get; set; }
        public string id_str { get; set; }
        public string in_reply_to_screen_name { get; set; }
        public Int64? in_reply_to_status_id { get; set; }
        public string in_reply_to_status_id_str { get; set; }
        public Int64? in_reply_to_user_id { get; set; }
        public string in_reply_to_user_id_str { get; set; }
        public Place place { get; set; }
        public bool? possibly_sensitive { get; set; }
        public Dictionary<string, string> scopes { get; set; }
        public int? reweet_count { get; set; }
        public bool? retweeted { get; set; }
        public string source { get; set; }
        public string text { get; set; }
        public bool? truncated { get; set; }
        public User user { get; set; }
        public bool? withheld_copyright { get; set; }
        public string[] withheld_in_countries { get; set; }
        public string withheld_scope { get; set; }
    }
}