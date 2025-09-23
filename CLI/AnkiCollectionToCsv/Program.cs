using System.Dynamic;
using System.Text.RegularExpressions;
using AnkiCollectionIO.Schemas.Anki2;
using CsvHelper;
using CsvHelper.Configuration;

static partial class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        if (args.Length < 2)
        {
            throw new Exception("Invalid arguments. ([0]: path to anki2, [1]: path to output dictionary)");
        }

        string pathToCollection = args[0];
        string pathToOutput = args[1];

        Func<string, string> injector = value => value.Trim().Replace("&nbsp;" , " ");

        Directory.CreateDirectory(pathToOutput);
        Anki2DbContext dbContext = new(pathToCollection, true);
        IEnumerable<NoteType> noteTypes = dbContext.NoteTypes;
        foreach (NoteType noteType in noteTypes)
        {
            IEnumerable<dynamic> notes = dbContext.Notes
                .Where(note => note.NoteTypeId == noteType.Id)
                .OrderBy(note => note.SortField)
                .Select(note => DictionaryToDynamic(note.GetFieldsDictionary(dbContext, injector)));

            if (!notes.Any()) continue;

            Console.Write($"Writing note type {noteType.Name}...");

            using StreamWriter writer = new(Path.Combine(pathToOutput, $"{noteType.Name}.csv"));
            using CsvWriter csvWriter = new(writer, new CsvConfiguration(System.Globalization.CultureInfo.InvariantCulture) { NewLine = "\n" });
            csvWriter.WriteRecords(notes);

            Console.WriteLine("OK");
        }

        Console.WriteLine("Finish");
    }

    static dynamic DictionaryToDynamic(IDictionary<string, string> dictionary)
    {
        IDictionary<string, object> expandoObject = new ExpandoObject() as IDictionary<string, object>;
        foreach (KeyValuePair<string, string> dictElement in dictionary)
        {
            string value = SoundRegex().Replace(dictElement.Value, "");
            expandoObject.Add(new KeyValuePair<string, object>(dictElement.Key, value));
        }

        return expandoObject;
    }

    [GeneratedRegex(@"\[sound:.+?\]")]
    private static partial Regex SoundRegex();
}

