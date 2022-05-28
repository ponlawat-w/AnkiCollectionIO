using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AnkiCollectionIO.Schemas.Anki2;

[Table("graves")]
[Index("UserNumber", Name = "idx_graves_pending")]
public partial class Grave
{
    [Key]
    [Column("oid", TypeName = "integer")]
    public long OldId { get; set; }

    [Key]
    [Column("type", TypeName = "integer")]
    public long Type { get; set; }

    [Column("usn", TypeName = "integer")]
    public long UserNumber { get; set; }
}
