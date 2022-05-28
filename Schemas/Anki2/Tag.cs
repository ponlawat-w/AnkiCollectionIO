using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnkiCollectionIO.Schemas.Anki2;

[Table("tags")]
public partial class Tag
{
    [Key]
    [Column("tag", TypeName = "text")]
    public string Name { get; set; } = null!;

    [Column("usn", TypeName = "integer")]
    public long UserNumber { get; set; }

    [Column("collapsed", TypeName = "boolean")]
    public byte[] Collapsed { get; set; } = null!;

    [Column("config", TypeName = "blob")]
    public byte[]? Config { get; set; }
}
