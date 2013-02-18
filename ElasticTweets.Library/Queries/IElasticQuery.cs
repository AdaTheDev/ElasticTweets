using Nest.FactoryDsl;

namespace ElasticTweets.Library.Queries
{
    public interface IElasticQuery
    {
        string Description { get; }
        string RawQueryText { get; }
        SearchBuilder Builder { get; }
    }    
}
