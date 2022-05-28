using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AnkiCollectionIO.Schemas.Anki2;

[Table("decks")]
[Index("Name", Name = "idx_decks_name", IsUnique = true)]
public partial class Deck
{
    [Key]
    [Column("id", TypeName = "integer")]
    public long Id { get; set; }

    [Column("name", TypeName = "text")]
    public string Name { get; set; } = null!;

    [Column("mtime_secs", TypeName = "integer")]
    public long MTimeSecs { get; set; }

    [Column("usn", TypeName = "integer")]
    public long UserNumber { get; set; }

    [Column("common", TypeName = "blob")]
    public byte[] Common { get; set; } = null!;

    [Column("kind", TypeName = "blob")]
    public byte[] Kind { get; set; } = null!;
}
