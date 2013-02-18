using System.Collections.Generic;
using ElasticTweets.Library.Data;

namespace ElasticTweets.Library.IO
{
    public interface ITweetDataFileParser
    {
        IEnumerable<Tweet> GetTweets(string fileName);
    }
}