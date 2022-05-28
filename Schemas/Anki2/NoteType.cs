using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AnkiCollectionIO.Schemas.Anki2;

[Table("notetypes")]
[Index("Name", Name = "idx_notetypes_name", IsUnique = true)]
[Index("UserNumber", Name = "idx_notetypes_usn")]
public partial class NoteType
{
    [Key]
    [Column("id", TypeName = "integer")]
    public long Id { get; set; }

    [Column("name", TypeName = "text")]
    public string Name { get; set; } = null!;

    [Column("mtime_secs", TypeName = "integer")]
    public long ModifiedTimeSeconds { get; set; }

    [Column("usn", TypeName = "integer")]
    public long UserNumber { get; set; }

    [Column("config", TypeName = "blob")]
    public byte[] Config { get; set; } = null!;

    public Field[] GetFields(Anki2DbContext dbContext)
    {
        return dbContext.Fields.Where(field => Id == field.NoteTypeId).ToArray();
    }
}
