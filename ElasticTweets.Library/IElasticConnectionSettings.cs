namespace ElasticTweets.Library
{
    public interface IElasticConnectionSettings
    {
        string Host { get; }
        int Port { get; }
        string IndexName { get; }
    }
}