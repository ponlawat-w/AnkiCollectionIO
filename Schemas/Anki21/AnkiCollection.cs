using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace AnkiCollectionIO.Schemas.Anki21
{
    [Table("col")]
    public partial class AnkiCollection
    {
        [Key]
        [Column("id", TypeName = "integer")]
        public long Id { get; set; }

        [Column("crt", TypeName = "integer")]
        public long Crt { get; set; }

        [Column("mod", TypeName = "integer")]
        public long ModifiedTimestamp { get; set; }

        [Column("scm", TypeName = "integer")]
        public long Scm { get; set; }

        [Column("ver", TypeName = "integer")]
        public long Ver { get; set; }

        [Column("dty", TypeName = "integer")]
        public long Dty { get; set; }

        [Column("usn", TypeName = "integer")]
        public long Usn { get; set; }

        [Column("ls", TypeName = "integer")]
        public long Ls { get; set; }

        [Required]
        [Column("conf", TypeName = "text")]
        public string ConfigJson { get; set; }

        [Required]
        [Column("models", TypeName = "text")]
        public string ModelsJson { get; set; }

        [Required]
        [Column("decks", TypeName = "text")]
        public string Decks { get; set; }

        [Required]
        [Column("dconf", TypeName = "text")]
        public string Dconf { get; set; }
        
        [Required]
        [Column("tags", TypeName = "text")]
        public string Tags { get; set; }

        public IEnumerable<Model> ToModels()
        {
            return JsonSerializer.Deserialize<IDictionary<string, Model>>(ModelsJson).Select(item => item.Value);
        }
    }
}
