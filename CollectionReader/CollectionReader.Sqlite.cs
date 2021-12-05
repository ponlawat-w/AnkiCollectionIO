using System;
using System.Collections.Generic;
using System.Linq;
using AnkiCollectionIO.Schemas;
using Microsoft.Data.Sqlite;

namespace AnkiCollectionIO
{
    public partial class CollectionReader
    {
        public AnkiCollectionDbContext DbContext;
        private SqliteConnection _connection;

        private void EstablishSqlite()
        {
            _connection = new SqliteConnection($"DataSource={SqlitePath}");
            DbContext = new AnkiCollectionDbContext(_connection);
        }

        public List<AnkiCollection> GetCollections()
        {
            return DbContext.Collections.ToList();
        }

        public AnkiCollection GetCollection()
        {
            return DbContext.Collections.FirstOrDefault();
        }

        public IEnumerable<Note> QueryNotes()
        {
            return DbContext.Notes;
        }
    }
}
