﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ElasticTweets.Library.Data;
using ElasticTweets.Library.IO;
using ElasticTweets.Library.Providers;
using Nest;
using Newtonsoft.Json;

namespace ElasticTweets.Library
{
    /// <summary>
    /// Imports tweet data from the .js files provided in the Twitter
    /// data export, into ElasticSearch
    /// </summary>
    public sealed class Importer
    {
        private readonly IFileSystem _fileSystem;
        private readonly IElasticConnectionSettings _elasticConnectionSettings;
        private readonly string _sourceDirectory;
        private readonly IClientProvider _clientProvider;
        private readonly ITweetDataFileParser _parser;
        
        public Importer(
            IFileSystem fileSystem, 
            ITweetDataFileParser tweetDataFileParser,
            IClientProvider clientProvider, 
            IElasticConnectionSettings elasticConnectionSettings, 
            string sourceDirectory)
        {
            if (fileSystem == null) throw new ArgumentNullException("fileSystem");
            if (tweetDataFileParser == null) throw new ArgumentNullException("tweetDataFileParser");
            if (clientProvider == null) throw new ArgumentNullException("clientProvider");
            if (elasticConnectionSettings == null) throw new ArgumentNullException("elasticConnectionSettings");
            
            if (!fileSystem.DirectoryExists(sourceDirectory))
                throw new DirectoryNotFoundException("Source directory does not exist");

            _fileSystem = fileSystem;
            _parser = tweetDataFileParser;
            _clientProvider = clientProvider;
            _elasticConnectionSettings = elasticConnectionSettings;
            _sourceDirectory = sourceDirectory;            
        }
        
        public IElasticConnectionSettings ElasticConnectionSettings
        {
            get { return _elasticConnectionSettings; }
        }

        public string SourceDirectory
        {
            get { return _sourceDirectory; }            
        }

        /// <summary>
        /// Iterates round each .js file in the source directory,
        /// deserializes the tweet data in each one and pushes into ElasticSearch.
        /// Each file = 1 month's worth of tweets. Currently, entire file is read in
        /// one go and all tweets pushed to ES in a batch.
        /// </summary>
        /// <returns>ImportResult</returns>
        public ImportResult Import()
        {
            var client = _clientProvider.GetClient(_elasticConnectionSettings);
            if (!client.IsValid)            
                throw new ElasticSearchException("Could not connect to ElasticSearch. Please check the connection settings");
            
            var results = new ImportResult();

            foreach (var file in _fileSystem.GetFiles(_sourceDirectory, "*.js"))
            {
                results.AddImportedFile(ProcessFile(file, client));
            }
            return results;
        }

        private ImportFileResult ProcessFile(string file, IElasticClient client)
        {
            ImportFileResult result;

            try
            {
                Tweet[] tweets = _parser.GetTweets(file).ToArray();

                result = tweets.Any() ? BuildFileResultFromClientResponse(file, client.IndexMany(tweets)) : new ImportFileResult(file, tweets.Count());
            }
            catch (JsonReaderException jsonReaderException)
            {
                // Dodgy file/invalid json
                result = new ImportFileResult(file, "File contains invalid JSON. Exception: " + jsonReaderException.Message);
            }

            return result;
        }

        private ImportFileResult BuildFileResultFromClientResponse(string file, IBulkResponse response)
        {
            if (response.ConnectionStatus.Success)            
                return new ImportFileResult(file, response.Items.Count());    
             
            return new ImportFileResult(file, response.ConnectionStatus.Error.ExceptionMessage);            
        }
    }    
}
