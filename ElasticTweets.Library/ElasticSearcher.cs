using System;
using System.Collections.Generic;
using ElasticTweets.Library.Data;
using ElasticTweets.Library.Providers;
using ElasticTweets.Library.Queries;
using Nest;
using Nest.FactoryDsl;

namespace ElasticTweets.Library
{
    public sealed class ElasticSearcher
    {
        private readonly IClientProvider _clientProvider;
        private readonly IElasticConnectionSettings _elasticConnectionSettings;
        private readonly IElasticClient _client;

        public ElasticSearcher(IClientProvider clientProvider, IElasticConnectionSettings elasticConnectionSettings)
        {
            if (clientProvider == null) throw new ArgumentNullException("clientProvider");
            if (elasticConnectionSettings == null) throw new ArgumentNullException("elasticConnectionSettings");

            _clientProvider = clientProvider;
            _elasticConnectionSettings = elasticConnectionSettings;
            _client = _clientProvider.GetClient(_elasticConnectionSettings);
        }

        public IEnumerable<Tweet> SearchRaw(IElasticQuery query)
        {
            var response = ExecuteRaw(query.RawQueryText);
            return Results(response);
        }

        public IEnumerable<Tweet> SearchClientApi(IElasticQuery query)
        {
            var response = ExecuteClient(query.Builder);
            return Results(response);
        }

        private IEnumerable<Tweet> Results(IQueryResponse<Tweet> response)
        {
            return response.Documents;
        }
        private IQueryResponse<Tweet> ExecuteRaw(string query)
        {
            return _client.SearchRaw<Tweet>(query); 
        }
        
        private IQueryResponse<Tweet> ExecuteClient(SearchBuilder searchBuilder)
        {            
            return _client.Search<Tweet>(searchBuilder);   
        }
    }
}