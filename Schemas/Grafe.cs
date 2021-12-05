using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace AnkiCollectionIO.Schemas
{
    [Keyless]
    [Table("graves")]
    public partial class Grafe
    {
        [Column("usn", TypeName = "integer")]
        public long Usn { get; set; }

        [Column("oid", TypeName = "integer")]
        public long Oid { get; set; }
        
        [Column("type", TypeName = "integer")]
        public long Type { get; set; }
    }
}
