using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AnkiCollectionIO.Schemas.Anki21
{
    public class ModelField
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("ord")]
        public long Ordinal { get; set; }

        [JsonPropertyName("sticky")]
        public bool Sticky { get; set; }

        [JsonPropertyName("rtl")]
        public bool Rtl { get; set; }

        [JsonPropertyName("font")]
        public string font { get; set; }

        [JsonPropertyName("size")]
        public long size { get; set; }

        [JsonPropertyName("media")]
        public IEnumerable<object> Media { get; set; }

    }
}
