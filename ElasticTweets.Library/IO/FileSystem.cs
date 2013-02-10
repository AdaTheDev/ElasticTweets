using System.IO;

namespace ElasticTweets.Library.IO
{
    public sealed class FileSystem : IFileSystem
    {
        public bool DirectoryExists(string directory)
        {
            return Directory.Exists(directory);
        }

        public bool FileExists(string path)
        {
            return File.Exists(path);
        }

        public string[] GetFiles(string directory, string pattern)
        {
            return Directory.GetFiles(directory, pattern);
        }

        public string ReadAllText(string path)
        {
            return File.ReadAllText(path);
        }
    }
}