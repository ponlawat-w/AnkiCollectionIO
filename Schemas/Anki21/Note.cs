using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace AnkiCollectionIO.Schemas.Anki21
{
    [Table("notes")]
    [Index(nameof(Csum), Name = "ix_notes_csum")]
    [Index(nameof(Usn), Name = "ix_notes_usn")]
    public partial class Note
    {
        public static char FieldSeparator = '';

        [Key]
        [Column("id", TypeName = "integer")]
        public long Id { get; set; }

        [Required]
        [Column("guid", TypeName = "text")]
        public string GUID { get; set; }

        [Column("mid", TypeName = "integer")]
        public long ModelID { get; set; }

        [Column("mod", TypeName = "integer")]
        public long ModifiedTimestamp { get; set; }

        [Column("usn", TypeName = "integer")]
        public long Usn { get; set; }

        [Required]
        [Column("tags", TypeName = "text")]
        public string Tags { get; set; }

        [Required]
        [Column("flds", TypeName = "text")]
        public string Fields { get; set; }

        [Column("sfld", TypeName = "integer")]
        public string SortField { get; set; }

        [Column("csum", TypeName = "integer")]
        public long Csum { get; set; }

        [Column("flags", TypeName = "integer")]
        public long Flags { get; set; }

        [Required]
        [Column("data", TypeName = "text")]
        public string Data { get; set; }

        public IDictionary<string, string> GetFieldValue(Model model, bool clean = false)
        {
            string[] splitedFields = Fields.Split(FieldSeparator);
            ModelField[] modelFields = model.Fields.OrderBy(mF => mF.Ordinal).ToArray();
            if (splitedFields.Length != modelFields.Length)
            {
                throw new FieldLengthMismatchedException(splitedFields.Length, modelFields.Length);
            }

            IDictionary<string, string> result = new Dictionary<string, string>();
            for (int i = 0; i < modelFields.Length; i++)
            {
                string value = splitedFields[i];
                if (clean)
                {
                    value = value.Replace("&nbsp;", " ").Trim();
                }

                result[modelFields[i].Name] = value;
            }

            return result;
        }
    }

    public class FieldLengthMismatchedException : Exception
    {
        public FieldLengthMismatchedException(long modelLength, long noteFieldLength)
            : base($"Model length {modelLength} does not match note field length {noteFieldLength}")
        {}
    }
}
