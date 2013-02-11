using System;
using NUnit.Framework;

// ReSharper disable InconsistentNaming
namespace ElasticTweets.Library.UnitTests
{
    [TestFixture]
    public class ImportFileResultFixture
    {
        private const string TestFileName = "File1.js";
        private const int TestNumberOfTweets = 123;
        private const string TestErrorMessage = "Went pop";

        [Test]
        public void Constructor_Success_SetsFileName()
        {
            var file = new ImportFileResult(TestFileName, TestNumberOfTweets);

            Assert.AreEqual(TestFileName, file.FileName);
        }

        [Test]
        public void Constructor_Success_SetsNumberOfTweets()
        {
            var file = new ImportFileResult(TestFileName, TestNumberOfTweets);

            Assert.AreEqual(TestNumberOfTweets, file.NumberOfTweets);
        }

        [Test]
        public void Constructor_Success_DefaultsErrorMessageToEmpty()
        {
            var file = new ImportFileResult(TestFileName, TestNumberOfTweets);

            Assert.AreEqual(String.Empty, file.ErrorMessage);
        }

        [Test]
        public void Constructor_Success_SetsSuccessFlagToTrue()
        {
            var file = new ImportFileResult(TestFileName, TestNumberOfTweets);

            Assert.IsTrue(file.Success);
        }        
        [Test]
        public void Constructor_Failure_SetsFileName()
        {
            var file = new ImportFileResult(TestFileName, TestErrorMessage);

            Assert.AreEqual(TestFileName, file.FileName);
        }
       
        [Test]
        public void Constructor_Failure_SetsErrorMessage()
        {
            var file = new ImportFileResult(TestFileName, TestErrorMessage);

            Assert.AreEqual(TestErrorMessage, file.ErrorMessage);
        }

        [Test]
        public void Constructor_Failure_SetsSuccessFlagToFalse()
        {
            var file = new ImportFileResult(TestFileName, TestErrorMessage);

            Assert.IsFalse(file.Success);
        }        
    }
}
// ReSharper restore InconsistentNaming