// ReSharper disable InconsistentNaming
namespace ElasticTweets.Library.Data
{
    public sealed class Entities
    {
        public Media[] media { get; set; }
        public Url[] urls { get; set; }
        public UserMention[] user_mentions { get; set; }
        public Hashtag[] hashtags { get; set;}
    }
}
// ReSharper restore InconsistentNaming