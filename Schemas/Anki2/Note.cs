using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AnkiCollectionIO.Schemas.Anki2;

[Table("notes")]
[Index("NoteTypeId", Name = "idx_notes_mid")]
[Index("Checksum", Name = "ix_notes_csum")]
[Index("UserNumber", Name = "ix_notes_usn")]
public partial class Note
{
    public static char FieldSeparator = '\u001f';

    [Key]
    [Column("id", TypeName = "integer")]
    public long Id { get; set; }

    [Column("guid", TypeName = "text")]
    public string Guid { get; set; } = null!;

    [Column("mid", TypeName = "integer")]
    public long NoteTypeId { get; set; }

    [Column("mod", TypeName = "integer")]
    public long Modified { get; set; }

    [Column("usn", TypeName = "integer")]
    public long UserNumber { get; set; }

    [Column("tags", TypeName = "text")]
    public string Tags { get; set; } = null!;

    [Column("flds", TypeName = "text")]
    public string Fields { get; set; } = null!;

    [Column("sfld", TypeName = "integer")]
    public long SortField { get; set; }

    [Column("csum", TypeName = "integer")]
    public long Checksum { get; set; }

    [Column("flags", TypeName = "integer")]
    public long Flags { get; set; }

    [Column("data", TypeName = "text")]
    public string Data { get; set; } = null!;

    public NoteType GetNoteType(Anki2DbContext dbContext)
    {
        return dbContext.NoteTypes.Where(noteType => noteType.Id == NoteTypeId).First();
    }

    public IDictionary<string, string> GetFieldsDictionary(Field[] fields, Func<string, string>? valueInjector = null)
    {
        string[] values = Fields.Split(FieldSeparator);
        if (fields.Length != values.Length)
        {
            throw new FieldLengthMismatchedException(fields.Length, values.Length);
        }
        
        IDictionary<string, string> dict = new Dictionary<string, string>();
        for (int i = 0; i < fields.Length; i++)
        {
            Field field = fields[i];
            dict[field.Name] = valueInjector == null ? values[i] : valueInjector(values[i]);
        }

        return dict;
    }

    public IDictionary<string, string> GetFieldsDictionary(Anki2DbContext dbContext, Func<string, string>? valueInjector = null)
    {
        Field[] fields = GetNoteType(dbContext).GetFields(dbContext);
        return GetFieldsDictionary(fields, valueInjector);
    }
}

public class FieldLengthMismatchedException : Exception
{
    public FieldLengthMismatchedException(long noteTypeFieldsLength, long noteFieldsLength)
        : base($"Note type field length {noteTypeFieldsLength} does not match this note field value length {noteFieldsLength}")
    {}
}
