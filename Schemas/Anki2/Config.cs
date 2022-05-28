using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnkiCollectionIO.Schemas.Anki2;

[Table("config")]
public partial class Config
{
    [Key]
    [Column("KEY", TypeName = "text")]
    public string Key { get; set; } = null!;

    [Column("usn", TypeName = "integer")]
    public long UserNumber { get; set; }

    [Column("mtime_secs", TypeName = "integer")]
    public long MTimeSecs { get; set; }

    [Column("val", TypeName = "blob")]
    public byte[] Val { get; set; } = null!;
}
