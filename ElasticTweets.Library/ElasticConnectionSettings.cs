using System;

namespace ElasticTweets.Library
{
    public sealed class ElasticConnectionSettings : IElasticConnectionSettings
    {
        private readonly string _host;
        private readonly int _port;
        private readonly string _indexName;

        public ElasticConnectionSettings(string host, int port, string indexName)
        {            
            if (String.IsNullOrWhiteSpace(host)) throw new ArgumentException("Host must be supplied", "host");
            if (String.IsNullOrWhiteSpace(indexName)) throw new ArgumentException("Index Name must be supplied", "indexName");

            _host = host;
            _port = port;
            _indexName = indexName;
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