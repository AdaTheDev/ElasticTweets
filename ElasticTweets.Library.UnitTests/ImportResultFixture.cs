using System;
using System.Linq;
using NUnit.Framework;

// ReSharper disable InconsistentNaming
namespace ElasticTweets.Library.UnitTests
{
    [TestFixture]
    public class ImportResultFixture
    {
        [Test]
        public void Constructor_DefaultsImportedFilesToEmptyArray()
        {
            var result = new ImportResult();

            Assert.IsEmpty(result.Files);
        }

        [Test]        
        public void AddImportedFile_AddsFileResult()
        {
            var result = new ImportResult();
            var file = new ImportFileResult("1.txt", 123);
            
            result.AddImportedFile(file);

            Assert.AreEqual(1, result.Files.Count(), "Expected 1 file in Files" );
            Assert.That(result.Files.Any(f => f == file), "Expected file not found");
        }

        [Test]
        [ExpectedException(typeof (ArgumentNullException))]
        public void AddImportedFile_ThrowsForNullFile()
        {
            var result = new ImportResult();

            try
            {
                result.AddImportedFile(null);
            }
            catch (ArgumentNullException exception)
            {
                Assert.AreEqual("file", exception.ParamName);
                throw;
            }
        }
    }
}
// ReSharper restore InconsistentNaming