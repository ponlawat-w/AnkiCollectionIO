using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AnkiCollectionIO.Schemas.Anki21
{
    public class Model
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("type")]
        public long Type { get; set; }

        [JsonPropertyName("mod")]
        public long Mod { get; set; }

        [JsonPropertyName("usn")]
        public long Usn { get; set; }

        [JsonPropertyName("sortf")]
        public long SortField { get; set; }

        [JsonPropertyName("did")]
        public long? DeckId { get; set; }

        [JsonPropertyName("tmpls")]
        public IEnumerable<ModelTemplate> Templates { get; set; }

        [JsonPropertyName("flds")]
        public IEnumerable<ModelField> Fields { get; set; }

        [JsonPropertyName("css")]
        public string Css { get; set; }

        [JsonPropertyName("latexPre")]
        public string LatexPre { get; set; }

        [JsonPropertyName("latexPost")]
        public string LatexPost { get; set; }

        [JsonPropertyName("latexsvg")]
        public bool LatexSvg { get; set; }

        [JsonPropertyName("req")]
        public IEnumerable<object> Req { get; set; }

        [JsonPropertyName("vers")]
        public IEnumerable<object> vers { get; set; }

        [JsonPropertyName("tags")]
        public IEnumerable<object> tags { get; set; }

    }
}
