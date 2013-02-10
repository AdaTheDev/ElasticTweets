using System;
using Nest;

namespace ElasticTweets.Library.Providers
{
    public sealed class ClientProvider : IClientProvider
    {
        public IElasticClient GetClient(IElasticConnectionSettings settings)
        {
            if (settings == null) throw new ArgumentNullException("settings");

            var connectionSettings = new ConnectionSettings(settings.Host, settings.Port);
            connectionSettings.SetDefaultIndex(settings.IndexName);
            return new ElasticClient(connectionSettings);
        }
    }
}
