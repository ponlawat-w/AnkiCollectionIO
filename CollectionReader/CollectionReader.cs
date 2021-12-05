using System;
using System.IO;

namespace AnkiCollectionIO
{
    public partial class CollectionReader : IDisposable
    {
        public string CollectionPath { get; }
        public string ExtractedDirectoryPath { get; }
        public string SqlitePath { get; private set; }

        public CollectionReader(string collectionPath, string extractedDirectory = "./temp/", bool overwriteExtracted = true)
        {
            if (!File.Exists(collectionPath))
            {
                throw new FileNotFoundException($"File {collectionPath} not found.", collectionPath);
            }

            CollectionPath = collectionPath;
            ExtractedDirectoryPath = extractedDirectory;

            SqlitePath = Extract(overwriteExtracted);
            EstablishSqlite();
        }

        public void Dispose()
        {
            DbContext.Dispose();
            _connection.Close();
            Microsoft.Data.Sqlite.SqliteConnection.ClearAllPools();
            GC.Collect();
            GC.WaitForPendingFinalizers();
            Directory.Delete(ExtractedDirectoryPath, true);
        }
    }
}
