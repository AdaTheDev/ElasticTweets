using System;
using ElasticTweets.Library.UnitTests.Common;
using NUnit.Framework;

// ReSharper disable InconsistentNaming
namespace ElasticTweets.Library.UnitTests
{
    [TestFixture]
    public class ElasticConnectionSettingsFixture
    {
        private const string TestHost = "TestHost";
        private const string TestIndexName = "TestIndex";
        private const int TestPort = 123;
        private ElasticConnectionSettings _settings;
        
        private void InitialiseSettings()
        {
            _settings = new ElasticConnectionSettings(TestHost, TestPort, TestIndexName);
        }
        #region Constructor Tests
        [Test]
        [TestCaseSource(typeof(TestCases), "NullOrWhiteSpaceStrings")]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_ThrowsWhenHostNotSupplied(string host)
        {
            try
            {
// ReSharper disable ObjectCreationAsStatement
                new ElasticConnectionSettings(host, TestPort, TestIndexName);
// ReSharper restore ObjectCreationAsStatement
            }
            catch (ArgumentException argumentException)
            {
                Assert.AreEqual("host", argumentException.ParamName, "Invalid ParamName");
                throw;
            }
        }

        [Test]
        [TestCaseSource(typeof(TestCases), "NullOrWhiteSpaceStrings")]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_ThrowsWhenIndexnameNotSupplied(string indexName)
        {
            try
            {
                // ReSharper disable ObjectCreationAsStatement
                new ElasticConnectionSettings(TestHost, TestPort, indexName);
                // ReSharper restore ObjectCreationAsStatement
            }
            catch (ArgumentException argumentException)
            {
                Assert.AreEqual("indexName", argumentException.ParamName, "Invalid ParamName");
                throw;
            }
        }

        [Test]
        public void Constructor_SetsHost()
        {
            InitialiseSettings();
    
            Assert.AreEqual(TestHost, _settings.Host);
        }

        [Test]
        public void Constructor_SetsPort()
        {
            InitialiseSettings();

            Assert.AreEqual(TestPort, _settings.Port);
        }


        [Test]
        public void Constructor_SetsIndexName()
        {
            InitialiseSettings();

            Assert.AreEqual(TestIndexName, _settings.IndexName);
        }
        #endregion

    }
}
// ReSharper restore InconsistentNaming