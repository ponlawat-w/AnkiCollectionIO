using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnkiCollectionIO.Schemas.Anki2;

[Table("deck_config")]
public partial class DeckConfig
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

    [Column("config", TypeName = "blob")]
    public byte[] Config { get; set; } = null!;
}
