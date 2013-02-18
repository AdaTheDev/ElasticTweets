// ReSharper disable InconsistentNaming
namespace ElasticTweets.Library.Data
{
    public sealed class BoundingBox
    {
        public int[][] coordinates { get; set; }
        public string type { get; set; }
    }
}
// ReSharper restore InconsistentNaming