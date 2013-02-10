using Nest;

namespace ElasticTweets.Library.Providers
{
    public interface IClientProvider
    {
        IElasticClient GetClient(IElasticConnectionSettings settings);
    }
}