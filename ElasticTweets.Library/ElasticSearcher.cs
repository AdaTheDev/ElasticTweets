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

        public IEnumerable<Tweet> SearchRaw(IElasticQuery query, int maxDocuments)
        {
            var response = ExecuteRaw(query.RawQueryText, maxDocuments);
            return Results(response);
        }

        public IEnumerable<Tweet> Search(IElasticQuery query, int maxDocuments)
        {
            var response = ExecuteDsl(query.Query, maxDocuments);
            return Results(response);
        }

        private IEnumerable<Tweet> Results(IQueryResponse<Tweet> response)
        {
            return response.Documents;
        }

        private IQueryResponse<Tweet> ExecuteRaw(string query, int maxDocuments)
        {
            var searchBuilder = new SearchBuilder();
            searchBuilder.Query(query).Size(maxDocuments);
            return _client.Search<Tweet>(searchBuilder);
        }
        
        private IQueryResponse<Tweet> ExecuteDsl(QueryDescriptor<Tweet> query, int maxDocuments)
        {            
            return _client.Search<Tweet>(s => s.Query(query).Size(maxDocuments));               
        }
    }
}