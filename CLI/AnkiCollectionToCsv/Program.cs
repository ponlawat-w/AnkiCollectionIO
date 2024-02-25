using System.Dynamic;
using AnkiCollectionIO.Schemas.Anki2;
using CsvHelper;
using CsvHelper.Configuration;

static class Program
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
        List<NoteType> noteTypes = dbContext.NoteTypes.ToList();
        foreach (NoteType noteType in noteTypes)
        {
            dynamic[] notes = dbContext.Notes
                .Where(note => note.NoteTypeId == noteType.Id)
                .OrderBy(note => note.SortField)
                .Select(note => DictionaryToDynamic(note.GetFieldsDictionary(dbContext, injector)))
                .ToArray();
            
            if (notes.Length == 0)
            {
                continue;
            }

            Console.Write($"Writing note type {noteType.Name}...");

            using (StreamWriter writer = new(Path.Combine(pathToOutput, $"{noteType.Name}.csv")))
            using (CsvWriter csvWriter = new(writer, new CsvConfiguration(System.Globalization.CultureInfo.InvariantCulture){ NewLine = "\n" }))
            {
                csvWriter.WriteRecords(notes);
            }

            Console.WriteLine("OK");
        }

        Console.WriteLine("Finish");
    }

    static dynamic DictionaryToDynamic(IDictionary<string, string> dictionary)
    {
        IDictionary<string, object> expandoObject = new ExpandoObject() as IDictionary<string, object>;
        foreach (KeyValuePair<string, string> dictElement in dictionary)
        {
            expandoObject.Add(new KeyValuePair<string, object>(dictElement.Key, dictElement.Value));
        }

        return expandoObject;
    }
}

