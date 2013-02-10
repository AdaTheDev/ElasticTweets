using NUnit.Framework;

// ReSharper disable InconsistentNaming
namespace ElasticTweets.Library.UnitTests
{
    [TestFixture]
    public class ImportedFileFixture
    {
        private const string TestFileName = "File1.js";
        private const int TestNumberOfTweets = 123;

        [Test]
        public void Constructor_SetsFileName()
        {
            var file = new ImportedFile(TestFileName, TestNumberOfTweets);

            Assert.AreEqual(TestFileName, file.FileName);
        }

        [Test]
        public void Constructor_SetsNumberOfTweets()
        {
            var file = new ImportedFile(TestFileName, TestNumberOfTweets);

            Assert.AreEqual(TestNumberOfTweets, file.NumberOfTweets);
        }
    }
}
// ReSharper restore InconsistentNaming