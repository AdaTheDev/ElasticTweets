using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace ElasticTweets.Library.IO
{
    /// <summary>
    /// Responsible for pulling tweet data of the .js format files into a useable form,
    /// currently dynamic objects.
    /// </summary>
    public sealed class TweetDataFileParser : ITweetDataFileParser
    {
        private readonly IFileSystem _fileSystem;

        public TweetDataFileParser(IFileSystem fileSystem)
        {
            _fileSystem = fileSystem;
        }

        /// <summary>
        /// Extract the tweets in the supplied .js file (as exported by Twitter) into
        /// an enumerable of dynamics.
        /// From the readme that comes with the Twitter data download:
        /// "To consume the export in a generic JSON parser in any language, strip the 
        /// first and last lines of each file". Actually, just need to strip the first line off.
        /// This reads in the entire file in one go (one file = 1 month's worth of tweets)
        /// </summary>
        /// <param name="fileName">.js tweet file to get tweets from</param>
        /// <returns>enumerable of dynamics</returns>
        public IEnumerable<dynamic> GetTweets(string fileName)
        {
            if (!fileName.ToLowerInvariant().EndsWith(".js"))
                throw new ArgumentException("Expected to receive a .js file", "fileName");

            if (!_fileSystem.FileExists(fileName))
                throw new FileNotFoundException("Tweet data file not found", fileName);

            string fileText = _fileSystem.ReadAllText(fileName);

            if (String.IsNullOrWhiteSpace(fileText))
                return Enumerable.Empty<dynamic>();

            // Remove the first line
            int firstNewLineChar = fileText.IndexOf('\n');
            if (firstNewLineChar < 0)
                return Enumerable.Empty<dynamic>();
            
            fileText = fileText.Remove(0, firstNewLineChar + 1);

            // Deserialize all the tweets in the file
            return JsonConvert.DeserializeObject<dynamic>(fileText);            
        }
    }
}
