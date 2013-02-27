using ElasticTweets.Library.Data;
using Nest;

namespace ElasticTweets.Library.Queries
{
    public interface IElasticQuery
    {
        string Description { get; }
        string RawQueryText { get; }
        QueryDescriptor<Tweet> Query { get; }
    }    
}
