using System;

namespace ElasticTweets.Library
{
    public sealed class ImportFileResult
    {
        private readonly string _fileName;
        private readonly int _numberOfTweets;
        private readonly string _errorMessage;
        private readonly bool _success;

        public ImportFileResult(string fileName, int numberOfTweets)
        {
            _fileName = fileName;
            _numberOfTweets = numberOfTweets;
            _errorMessage = String.Empty;
            _success = true;
        }

        public ImportFileResult(string fileName, string errorMessage)
        {
            _fileName = fileName;
            _errorMessage = errorMessage;
            _success = false;
        }

        public string FileName
        {
            get { return _fileName; }            
        }

        public int NumberOfTweets
        {
            get { return _numberOfTweets; }
        }

        public string ErrorMessage
        {
            get { return _errorMessage; }
        }

        public bool Success
        {
            get { return _success; }
        }
    }
}