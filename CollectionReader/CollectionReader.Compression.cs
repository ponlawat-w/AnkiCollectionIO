using System.IO;
using System.IO.Compression;

namespace AnkiCollectionIO
{
    public partial class CollectionReader
    {
        private string Extract(bool overwriteFiles = false)
        {
            Directory.CreateDirectory(ExtractedDirectoryPath);

            ZipFile.ExtractToDirectory(CollectionPath, ExtractedDirectoryPath, overwriteFiles);

            string sqlitePath = Path.Combine(ExtractedDirectoryPath, "collection.anki21");
            if (!File.Exists(sqlitePath))
            {
                throw new InvalidCollectionException(sqlitePath);
            }

            return sqlitePath;
        }
    }

    public class InvalidCollectionException : System.IO.FileNotFoundException
    {
        public InvalidCollectionException(string filePath)
            : base("'collection.anki21' Not found in extracted files", filePath)
        {}
    }
}
