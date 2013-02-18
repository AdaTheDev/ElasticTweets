// ReSharper disable InconsistentNaming
namespace ElasticTweets.Library.Data
{
    public class UserMention : UserIdentifier
    {
        public string screen_name { get; set; }
        public string name { get; set; }
        public int[] indices { get; set; }
    }
}
// ReSharper restore InconsistentNaming