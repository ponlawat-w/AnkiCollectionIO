using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace AnkiCollectionIO.Schemas.Anki2;

public partial class Anki2DbContext : DbContext
{
    public SqliteConnection Connection { get; private set; }

    public Anki2DbContext()
    {
        Connection = new SqliteConnection();
    }

    public Anki2DbContext(string datasourcePath, bool readOnly = false)
    {
        Connection = new SqliteConnection(new SqliteConnectionStringBuilder
        {
            DataSource = $"file:{datasourcePath}" + (readOnly ? "?immutable=1" : ""),
            Mode = readOnly ? SqliteOpenMode.ReadOnly : SqliteOpenMode.ReadWrite
        }.ToString());
    }

    public Anki2DbContext(DbContextOptions<Anki2DbContext> options)
        : base(options)
    {
        Connection = new SqliteConnection();
    }

    public virtual DbSet<Card> Cards { get; set; } = null!;
    public virtual DbSet<Collection> Cols { get; set; } = null!;
    public virtual DbSet<Config> Configs { get; set; } = null!;
    public virtual DbSet<Deck> Decks { get; set; } = null!;
    public virtual DbSet<DeckConfig> DeckConfigs { get; set; } = null!;
    public virtual DbSet<Field> Fields { get; set; } = null!;
    public virtual DbSet<Grave> Graves { get; set; } = null!;
    public virtual DbSet<Note> Notes { get; set; } = null!;
    public virtual DbSet<NoteType> NoteTypes { get; set; } = null!;
    public virtual DbSet<ReviewLog> Revlogs { get; set; } = null!;
    public virtual DbSet<Tag> Tags { get; set; } = null!;
    public virtual DbSet<Template> Templates { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlite(Connection);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Card>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Collection>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Deck>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<DeckConfig>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Field>(entity =>
        {
            entity.HasKey(e => new { e.NoteTypeId, e.Order });
        });

        modelBuilder.Entity<Grave>(entity =>
        {
            entity.HasKey(e => new { e.OldId, e.Type });
        });

        modelBuilder.Entity<Note>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<NoteType>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<ReviewLog>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Template>(entity =>
        {
            entity.HasKey(e => new { e.NoteTypeId, e.Order });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
