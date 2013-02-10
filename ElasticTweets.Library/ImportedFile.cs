namespace ElasticTweets.Library
{
    public sealed class ImportedFile
    {
        private readonly string _fileName;
        private readonly int _numberOfTweets;

        public ImportedFile(string fileName, int numberOfTweets )
        {
            _fileName = fileName;
            _numberOfTweets = numberOfTweets;
        }

        public string FileName
        {
            get { return _fileName; }            
        }

        public int NumberOfTweets
        {
            get { return _numberOfTweets; }
        }
    }
}