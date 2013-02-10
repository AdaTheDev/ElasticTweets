using System;
using System.Collections.Generic;

namespace ElasticTweets.Library
{
    public class ImportResult
    {
        private readonly List<ImportedFile> _importedFiles;

        public ImportResult()
        {
            _importedFiles = new List<ImportedFile>();
        }        
        
        public IEnumerable<ImportedFile> ImportedFiles
        {
            get { return _importedFiles.AsReadOnly();}
        }

        public void AddImportedFile(ImportedFile file)
        {
            if (file == null) throw new ArgumentNullException("file");
            _importedFiles.Add(file);
        }
    }
}