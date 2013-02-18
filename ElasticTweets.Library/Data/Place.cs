// ReSharper disable InconsistentNaming
namespace ElasticTweets.Library.Data
{
    public sealed class Place
    {
        public dynamic attributes { get; set; }
        public BoundingBox bounding_box { get; set; }
        public string country { get; set; }
        public string country_code { get; set; }
        public string full_name { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public string place_type { get; set; }
        public string url { get; set; }
    }
}
// ReSharper restore InconsistentNaming