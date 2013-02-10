using System.Collections.Generic;

namespace ElasticTweets.Library.IO
{
    public interface ITweetDataFileParser
    {
        IEnumerable<object> GetTweets(string fileName);
    }
}