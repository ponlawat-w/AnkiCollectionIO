using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AnkiCollectionIO.Schemas.Anki2;

[Table("templates")]
[Index("Name", "NoteTypeId", Name = "idx_templates_name_ntid", IsUnique = true)]
[Index("UserNumber", Name = "idx_templates_usn")]
public partial class Template
{
    [Key]
    [Column("ntid", TypeName = "integer")]
    public long NoteTypeId { get; set; }

    [Key]
    [Column("ord", TypeName = "integer")]
    public long Order { get; set; }

    [Column("name", TypeName = "text")]
    public string Name { get; set; } = null!;

    [Column("mtime_secs", TypeName = "integer")]
    public long ModifiedTimeSecs { get; set; }

    [Column("usn", TypeName = "integer")]
    public long UserNumber { get; set; }

    [Column("config", TypeName = "blob")]
    public byte[] Config { get; set; } = null!;
}
