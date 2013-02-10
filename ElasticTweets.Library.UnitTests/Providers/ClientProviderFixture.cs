using System;
using ElasticTweets.Library.Providers;
using Moq;
using NUnit.Framework;
using Nest;

// ReSharper disable InconsistentNaming
namespace ElasticTweets.Library.UnitTests.Providers
{
    [TestFixture]
    public class ClientProviderFixture
    {
        private ClientProvider _clientProvider;
        private Mock<IElasticConnectionSettings> _mockedSettings;

        [SetUp]
        public void Setup()
        {
            _clientProvider = new ClientProvider();
            _mockedSettings = new Mock<IElasticConnectionSettings>(MockBehavior.Strict);
            _mockedSettings.Setup(s => s.Host).Returns("localhost");
            _mockedSettings.Setup(s => s.Port).Returns(1);
            _mockedSettings.Setup(s => s.IndexName).Returns("ElasticTweetsUnitTesting");
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetClient_ThrowsWhenNullSettingsSupplied()
        {
            try
            {
                _clientProvider.GetClient(null);
            }
            catch (ArgumentNullException exception)
            {
                Assert.AreEqual("settings", exception.ParamName, "Incorrect ParamName");
                throw;
            }
        }

        [Test]
        public void GetClient_ReturnsElasticClient()
        {
            var client = _clientProvider.GetClient(_mockedSettings.Object);
            
            Assert.IsInstanceOf<ElasticClient>(client);
            _mockedSettings.Verify(s => s.Host, Times.Once());
            _mockedSettings.Verify(s => s.Port, Times.Once());
        }        
    }
}
// ReSharper restore InconsistentNaming
