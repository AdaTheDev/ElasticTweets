namespace ElasticTweets.Library.IO
{
    public interface IFileSystem
    {
        bool DirectoryExists(string directory);
        bool FileExists(string path);
        string[] GetFiles(string directory, string pattern);
        string ReadAllText(string path);
    }
}
