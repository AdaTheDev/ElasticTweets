// ReSharper disable InconsistentNaming
using System;

namespace ElasticTweets.Library.Data
{
    public sealed class Media
    {
        public string display_url { get; set; }
        public string expanded_url { get; set; }
        public Int64? id { get; set; }
        public string id_str { get; set; }
        public int[] indices { get; set; }
        public string media_url { get; set; }
        public string media_url_https { get; set; }
        public Size[] sizes { get; set; }
        public Int64? source_status_id { get; set; }
        public string source_status_id_str { get; set; }
        public string type { get; set; }
        public string url { get; set; }
    }
}
// ReSharper restore InconsistentNaming