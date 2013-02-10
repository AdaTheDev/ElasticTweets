﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ElasticTweets.Library.IO;
using ElasticTweets.Library.Providers;
using Moq;
using NUnit.Framework;
using Nest;

// ReSharper disable InconsistentNaming
namespace ElasticTweets.Library.UnitTests
{
    [TestFixture]
    public class ImporterFixture
    {
        private const string TestSourceDirectory = @"C:\Test-Not-Real\";

        private Importer _importer;
        private Mock<IFileSystem> _mockedFileSystem;
        private Mock<IElasticConnectionSettings> _mockedConnectionSettings;
        private Mock<IClientProvider> _mockedClientProvider;
        private Mock<IElasticClient> _mockedClient;
        private Mock<ITweetDataFileParser> _mockedFileParser;
        private List<dynamic> _testTweets;
        private Mock<IBulkResponse> _mockedClientResponse;

        [SetUp]
        public void Setup()
        {
            _mockedFileSystem = new Mock<IFileSystem>(MockBehavior.Strict);
            _mockedConnectionSettings = new Mock<IElasticConnectionSettings>(MockBehavior.Strict);        
            _mockedClientProvider = new Mock<IClientProvider>(MockBehavior.Strict);
            _mockedClient = new Mock<IElasticClient>(MockBehavior.Strict);
            _mockedFileParser = new Mock<ITweetDataFileParser>(MockBehavior.Strict);
            _mockedClientResponse = new Mock<IBulkResponse>(MockBehavior.Strict);
            _testTweets = new List<dynamic>();
        }

        public void InitialiseImporter()
        {
            _mockedFileSystem.Setup(fs => fs.DirectoryExists(TestSourceDirectory)).Returns(true);
            _mockedClientProvider.Setup(cp => cp.GetClient(_mockedConnectionSettings.Object))
                                 .Returns(_mockedClient.Object);
            _mockedFileParser.Setup(fp => fp.GetTweets(It.IsAny<string>())).Returns(_testTweets);
            _mockedClient.Setup(c => c.IndexMany(It.IsAny<IEnumerable<dynamic>>())).Returns(_mockedClientResponse.Object);

            _importer = new Importer(_mockedFileSystem.Object, _mockedFileParser.Object, _mockedClientProvider.Object, _mockedConnectionSettings.Object, TestSourceDirectory);
        }        

        #region Constructor Tests
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_ThrowsWhenNullConnectionSettingsSupplied()
        {
            try
            {
                // ReSharper disable ObjectCreationAsStatement
                new Importer(_mockedFileSystem.Object, _mockedFileParser.Object, _mockedClientProvider.Object, null, TestSourceDirectory);
                // ReSharper restore ObjectCreationAsStatement
            }
            catch (ArgumentNullException exception)
            {
                Assert.AreEqual("elasticConnectionSettings", exception.ParamName, "Incorrect ParamName");
                throw;
            }
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_ThrowsWhenNullFileSystemSupplied()
        {
            try
            {
                // ReSharper disable ObjectCreationAsStatement
                new Importer(null, _mockedFileParser.Object, _mockedClientProvider.Object, _mockedConnectionSettings.Object, TestSourceDirectory);
                // ReSharper restore ObjectCreationAsStatement
            }
            catch (ArgumentNullException exception)
            {
                Assert.AreEqual("fileSystem", exception.ParamName, "Incorrect ParamName");
                throw;
            }
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_ThrowsWhenNullClientProviderSupplied()
        {
            try
            {
                // ReSharper disable ObjectCreationAsStatement
                new Importer(_mockedFileSystem.Object, _mockedFileParser.Object, null, _mockedConnectionSettings.Object, TestSourceDirectory);
                // ReSharper restore ObjectCreationAsStatement
            }
            catch (ArgumentNullException exception)
            {
                Assert.AreEqual("clientProvider", exception.ParamName, "Incorrect ParamName");
                throw;
            }
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_ThrowsWhenNullFileParserSupplied()
        {
            try
            {
                // ReSharper disable ObjectCreationAsStatement
                new Importer(_mockedFileSystem.Object, null, _mockedClientProvider.Object, _mockedConnectionSettings.Object, TestSourceDirectory);
                // ReSharper restore ObjectCreationAsStatement
            }
            catch (ArgumentNullException exception)
            {
                Assert.AreEqual("tweetDataFileParser", exception.ParamName, "Incorrect ParamName");
                throw;
            }
        }


        [Test]        
        public void Constructor_ChecksSourceDirectoryExists()
        {
            _mockedFileSystem.Setup(fs => fs.DirectoryExists(It.IsAny<string>())).Returns(false);

            try
            {
                // ReSharper disable ObjectCreationAsStatement
                new Importer(_mockedFileSystem.Object, _mockedFileParser.Object, _mockedClientProvider.Object, _mockedConnectionSettings.Object, TestSourceDirectory);
                // ReSharper restore ObjectCreationAsStatement
// ReSharper disable EmptyGeneralCatchClause
            }catch{}
// ReSharper restore EmptyGeneralCatchClause
            
            _mockedFileSystem.Verify(fs => fs.DirectoryExists(TestSourceDirectory), Times.Once());
        }

        [Test]
        [ExpectedException(typeof(DirectoryNotFoundException))]
        public void Constructor_ThrowsWhenSourceDirectoryDoesNotExist()
        {
            _mockedFileSystem.Setup(fs => fs.DirectoryExists(It.IsAny<string>())).Returns(false);

            // ReSharper disable ObjectCreationAsStatement
            new Importer(_mockedFileSystem.Object, _mockedFileParser.Object, _mockedClientProvider.Object, _mockedConnectionSettings.Object, TestSourceDirectory);
            // ReSharper restore ObjectCreationAsStatement
        }

        [Test]
        public void Constructor_SetsConnectionSettings()
        {
            InitialiseImporter();

            Assert.AreSame(_mockedConnectionSettings.Object, _importer.ElasticConnectionSettings);
        }

        [Test]
        public void Constructor_SetsSourceDirectory()
        {
            InitialiseImporter();

            Assert.AreSame(TestSourceDirectory, _importer.SourceDirectory);
        }
        #endregion

       #region Import Tests
       [Test]
       public void Import_RetrievesFileNamesOnceThroughFileSystem()
       {
           InitialiseImporter();
           _mockedFileSystem.Setup(fs => fs.GetFiles(TestSourceDirectory, "*.js")).Returns(new[] {"1.js"});

           _importer.Import();

           _mockedFileSystem.Verify(fs => fs.GetFiles(TestSourceDirectory, "*.js"), Times.Once());
        }       

        [Test]
        public void Import_GetsClientFromClientProvider()
        {
            InitialiseImporter();
            _mockedFileSystem.Setup(fs => fs.GetFiles(TestSourceDirectory, "*.js")).Returns(new []{"1.js"});
            _mockedFileSystem.Setup(fs => fs.ReadAllText(It.IsAny<string>())).Returns("");
            
            _importer.Import();

            _mockedClientProvider.Verify(cp => cp.GetClient(_mockedConnectionSettings.Object), Times.Once());
        }

        [Test]
        public void Import_DoesNotCallElasticClientWhenNoTweetsPresent()
        {
            InitialiseImporter();
            _mockedFileSystem.Setup(fs => fs.GetFiles(TestSourceDirectory, "*.js")).Returns(new[] { "1.js" });
            _mockedFileSystem.Setup(fs => fs.ReadAllText(It.IsAny<string>())).Returns("");

            _importer.Import();

            _mockedClient.Verify(c => c.IndexMany(It.IsAny<IEnumerable<dynamic>>()), Times.Never());
        }

        [Test]
        public void Import_CallsElasticClientToIndexTweets()
        {
            InitialiseImporter();
            _mockedFileSystem.Setup(fs => fs.GetFiles(TestSourceDirectory, "*.js")).Returns(new[] { "1.js" });
            _mockedFileSystem.Setup(fs => fs.ReadAllText(It.IsAny<string>())).Returns("");            
            _testTweets.Add(new {id=1});
            
            _importer.Import();

            _mockedClient.Verify(c => c.IndexMany(It.IsAny<IEnumerable<dynamic>>()), Times.Once());
        }

        [Test]
        public void Import_ReturnsCorrectImportResult()
        {
            InitialiseImporter();
            _mockedFileSystem.Setup(fs => fs.GetFiles(TestSourceDirectory, "*.js")).Returns(new[] { "1.js" });
            _mockedFileSystem.Setup(fs => fs.ReadAllText(It.IsAny<string>())).Returns("");
            _testTweets.Add(new { id = 1 });

            var result = _importer.Import();

            Assert.AreEqual(1, result.ImportedFiles.Count(), "1 ImportedFile expected");
            var file = result.ImportedFiles.First();
            Assert.AreEqual(1, file.NumberOfTweets, "Incorrect NumberOfTweets");
            Assert.AreEqual("1.js", file.FileName, "Incorrect FileName");

        }
        #endregion
    }
}
// ReSharper restore InconsistentNaming