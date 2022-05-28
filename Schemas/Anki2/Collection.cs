using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnkiCollectionIO.Schemas.Anki2;

[Table("col")]
public partial class Collection
{
    [Key]
    [Column("id", TypeName = "integer")]
    public long Id { get; set; }

    [Column("crt", TypeName = "integer")]
    public long CreatedAt { get; set; }

    [Column("mod", TypeName = "integer")]
    public long LastModified { get; set; }

    [Column("scm", TypeName = "integer")]
    public long SchemaLastModified { get; set; }

    [Column("ver", TypeName = "integer")]
    public long Version { get; set; }

    [Column("dty", TypeName = "integer")]
    public long Dirty { get; set; }

    [Column("usn", TypeName = "integer")]
    public long UserNumber { get; set; }

    [Column("ls", TypeName = "integer")]
    public long LastSynced { get; set; }

    [Column("conf", TypeName = "text")]
    public string Configuration { get; set; } = null!;

    [Column("models", TypeName = "text")]
    public string Models { get; set; } = null!;

    [Column("decks", TypeName = "text")]
    public string Decks { get; set; } = null!;

    [Column("dconf", TypeName = "text")]
    public string DeckConfig { get; set; } = null!;

    [Column("tags", TypeName = "text")]
    public string Tags { get; set; } = null!;
}
