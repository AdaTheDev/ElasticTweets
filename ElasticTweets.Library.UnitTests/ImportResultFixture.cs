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

            Assert.IsEmpty(result.ImportedFiles);
        }

        [Test]        
        public void AddImportedFile_AddsFileResult()
        {
            var result = new ImportResult();
            var file = new ImportedFile("1.txt", 123);
            
            result.AddImportedFile(file);

            Assert.AreEqual(1, result.ImportedFiles.Count(), "Expected 1 file in ImportedFiles" );
            Assert.That(result.ImportedFiles.Any(f => f == file), "Expected file not found");
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