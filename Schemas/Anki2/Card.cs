using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AnkiCollectionIO.Schemas.Anki2;

[Table("cards")]
[Index("OriginalDeckId", Name = "idx_cards_odid")]
[Index("NoteId", Name = "ix_cards_nid")]
[Index("DeckId", "Queue", "Due", Name = "ix_cards_sched")]
[Index("UserNumber", Name = "ix_cards_usn")]
public partial class Card
{
    [Key]
    [Column("id", TypeName = "integer")]
    public long Id { get; set; }

    [Column("nid", TypeName = "integer")]
    public long NoteId { get; set; }

    [Column("did", TypeName = "integer")]
    public long DeckId { get; set; }

    [Column("ord", TypeName = "integer")]
    public long Order { get; set; }

    [Column("mod", TypeName = "integer")]
    public long LastModified { get; set; }

    [Column("usn", TypeName = "integer")]
    public long UserNumber { get; set; }

    [Column("type", TypeName = "integer")]
    public long Type { get; set; }

    [Column("queue", TypeName = "integer")]
    public long Queue { get; set; }

    [Column("due", TypeName = "integer")]
    public long Due { get; set; }

    [Column("ivl", TypeName = "integer")]
    public long Interval { get; set; }

    [Column("factor", TypeName = "integer")]
    public long Factor { get; set; }

    [Column("reps", TypeName = "integer")]
    public long Reviews { get; set; }

    [Column("lapses", TypeName = "integer")]
    public long Lapses { get; set; }

    [Column("left", TypeName = "integer")]
    public long Left { get; set; }

    [Column("odue", TypeName = "integer")]
    public long OriginalDue { get; set; }

    [Column("odid", TypeName = "integer")]
    public long OriginalDeckId { get; set; }

    [Column("flags", TypeName = "integer")]
    public long Flags { get; set; }

    [Column("data", TypeName = "text")]
    public string Data { get; set; } = null!;
}
