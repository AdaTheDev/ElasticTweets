using System;
using System.Collections.Generic;

namespace ElasticTweets.Library
{
    public class ImportResult
    {
        private readonly List<ImportFileResult> _importedFiles;

        public ImportResult()
        {
            _importedFiles = new List<ImportFileResult>();
        }        
        
        public IEnumerable<ImportFileResult> Files
        {
            get { return _importedFiles.AsReadOnly();}
        }

        public void AddImportedFile(ImportFileResult file)
        {
            if (file == null) throw new ArgumentNullException("file");
            _importedFiles.Add(file);
        }
    }
}