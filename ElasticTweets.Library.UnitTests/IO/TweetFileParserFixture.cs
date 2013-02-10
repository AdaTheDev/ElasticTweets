using System;
using System.IO;
using System.Linq;
using ElasticTweets.Library.IO;
using Moq;
using NUnit.Framework;

// ReSharper disable InconsistentNaming
namespace ElasticTweets.Library.UnitTests.IO
{
    [TestFixture]
    public class TweetFileParserFixture
    {
        private const string TestFileName = "test.js";
        private Mock<IFileSystem> _mockedFileSystem;
        private TweetDataFileParser _parser;        

        [SetUp]
        public void Setup()
        {
            _mockedFileSystem = new Mock<IFileSystem>(MockBehavior.Strict);
            _parser = new TweetDataFileParser(_mockedFileSystem.Object);
        }

        [Test]
        [ExpectedException(typeof(FileNotFoundException))]
        public void GetTweets_ThrowsIfFileDoesNotExist()
        {
            _mockedFileSystem.Setup(fs => fs.FileExists(It.IsAny<string>())).Returns(false);

            try
            {
                _parser.GetTweets(TestFileName);
            }
            catch (FileNotFoundException exception)
            {
                Assert.AreEqual(TestFileName,exception.FileName);
                throw;
            }
        }

        [Test]
        [TestCase("")]
        [TestCase("  ")]
        [TestCase("\n")]
        public void GetTweets_ReturnsEmptyEnumerableWhenFileContentsIsEmptyOrWhitespace(string contents)
        {
            _mockedFileSystem.Setup(fs => fs.FileExists(It.IsAny<string>())).Returns(true);
            _mockedFileSystem.Setup(fs => fs.ReadAllText(It.IsAny<string>())).Returns(contents);

            var tweets = _parser.GetTweets(TestFileName);

            Assert.IsEmpty(tweets);            
        }

        [Test]
        public void GetTweets_ChecksFileExistsBeforeProceeding()
        {
            _mockedFileSystem.Setup(fs => fs.FileExists(It.IsAny<string>())).Returns(false);
            _mockedFileSystem.Setup(fs => fs.ReadAllText(It.IsAny<string>())).Returns("");

            try
            {
                _parser.GetTweets(TestFileName);
            }
// ReSharper disable EmptyGeneralCatchClause
            catch{}
// ReSharper restore EmptyGeneralCatchClause
            
            _mockedFileSystem.Verify(fs => fs.FileExists(TestFileName), Times.Once());
            _mockedFileSystem.Verify(fs => fs.ReadAllText(It.IsAny<string>()), Times.Never());
        }

        [Test]
        public void GetTweets_RetrievesFileTextViaFileSystem()
        {
            _mockedFileSystem.Setup(fs => fs.FileExists(It.IsAny<string>())).Returns(true);
            _mockedFileSystem.Setup(fs => fs.ReadAllText(It.IsAny<string>())).Returns("");

            _parser.GetTweets(TestFileName);

            _mockedFileSystem.Verify(fs => fs.ReadAllText(TestFileName), Times.Once());
        }

        [Test]
        public void GetTweets_ReturnsEmptyEnumerableWhenFileDoesNotContainMultipleLines()
        {
            _mockedFileSystem.Setup(fs => fs.FileExists(It.IsAny<string>())).Returns(true);
            _mockedFileSystem.Setup(fs => fs.ReadAllText(It.IsAny<string>())).Returns("Line1");

            var tweets = _parser.GetTweets(TestFileName);

            Assert.IsEmpty(tweets);
        }

        [Test]
        public void GetTweets_ReturnsMultipleTweets()
        {
            _mockedFileSystem.Setup(fs => fs.FileExists(It.IsAny<string>())).Returns(true);
            _mockedFileSystem.Setup(fs => fs.ReadAllText(It.IsAny<string>())).Returns(Resources.TestFileContents.TwoTweets);

            var tweets = _parser.GetTweets(TestFileName).ToArray();

            Assert.AreEqual(2, tweets.Count());
            Assert.IsTrue(tweets.Any(t => t.text == "Dummy Tweet 1"), "Tweet 1 not found");
            Assert.IsTrue(tweets.Any(t => t.text == "Dummy Tweet 2 #Hashtag1"), "Tweet 2 not found");
        }     
   
        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void GetTweets_ThrowsForNonJsFile()
        {
            try
            {
                _parser.GetTweets("1.txt");
            }
            catch (ArgumentException exception)
            {
                Assert.AreEqual("fileName", exception.ParamName);
                throw;
            }
        }
    }
}
// ReSharper restore InconsistentNaming