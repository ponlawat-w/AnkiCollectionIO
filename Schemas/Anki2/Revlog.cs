using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AnkiCollectionIO.Schemas.Anki2;

[Table("revlog")]
[Index("CardId", Name = "ix_revlog_cid")]
[Index("UserNumber", Name = "ix_revlog_usn")]
public partial class ReviewLog
{
    [Key]
    [Column("id", TypeName = "integer")]
    public long Id { get; set; }

    [Column("cid", TypeName = "integer")]
    public long CardId { get; set; }

    [Column("usn", TypeName = "integer")]
    public long UserNumber { get; set; }

    [Column("ease", TypeName = "integer")]
    public long Ease { get; set; }

    [Column("ivl", TypeName = "integer")]
    public long Interval { get; set; }

    [Column("lastIvl", TypeName = "integer")]
    public long LastInterval { get; set; }

    [Column("factor", TypeName = "integer")]
    public long Factor { get; set; }

    [Column("time", TypeName = "integer")]
    public long Time { get; set; }

    [Column("type", TypeName = "integer")]
    public long Type { get; set; }
}
