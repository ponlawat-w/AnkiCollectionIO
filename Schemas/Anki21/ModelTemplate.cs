using System.Text.Json.Serialization;

namespace AnkiCollectionIO.Schemas.Anki21
{
    public class ModelTemplate
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("ord")]
        public long Ordinal { get; set; }

        [JsonPropertyName("qfmt")]
        public string QuestionFormat { get; set; }

        [JsonPropertyName("afmt")]
        public string AnswerFormat { get; set; }

        [JsonPropertyName("bqfmt")]
        public string BQuestionFormat { get; set; }

        [JsonPropertyName("bafmt")]
        public string BAnswerFormat { get; set; }

        [JsonPropertyName("did")]
        public long? DeckId { get; set; }

        [JsonPropertyName("bfont")]
        public string BFont { get; set; }

        [JsonPropertyName("bsize")]
        public long BSize { get; set; }

    }
}
