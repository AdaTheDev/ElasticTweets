using System;

namespace ElasticTweets.Library
{
    public sealed class ElasticConnectionSettings : IElasticConnectionSettings
    {
        private readonly string _host;
        private readonly int _port;
        private readonly string _indexName;

        /// <summary>
        /// Create a new instance of settings defining ElasticSearch connection
        /// details.
        /// </summary>
        /// <param name="host">ElasticSearch instance host name</param>
        /// <param name="port">port number to connect via</param>
        /// <param name="indexName">name of index. Will be forced to lowercase if not already
        /// as all index names in ElasticSearch much be lowercase otherwise you get an error</param>
        public ElasticConnectionSettings(string host, int port, string indexName)
        {            
            if (String.IsNullOrWhiteSpace(host)) throw new ArgumentException("Host must be supplied", "host");
            if (String.IsNullOrWhiteSpace(indexName)) throw new ArgumentException("Index Name must be supplied", "indexName");

            _host = host;
            _port = port;
            _indexName = indexName.ToLower();
        }

        public string Host
        {
            get { return _host; }
        }

        public int Port
        {
            get { return _port; }
        }
        
        public string IndexName
        {
            get { return _indexName; }
        }
    }
}