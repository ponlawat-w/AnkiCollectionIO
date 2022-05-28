using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AnkiCollectionIO.Schemas.Anki2;

[Table("fields")]
[Index("Name", "NoteTypeId", Name = "idx_fields_name_ntid", IsUnique = true)]
public partial class Field
{
    [Key]
    [Column("ntid", TypeName = "integer")]
    public long NoteTypeId { get; set; }

    [Key]
    [Column("ord", TypeName = "integer")]
    public long Order { get; set; }

    [Column("name", TypeName = "text")]
    public string Name { get; set; } = null!;

    [Column("config", TypeName = "blob")]
    public byte[] Config { get; set; } = null!;
}
