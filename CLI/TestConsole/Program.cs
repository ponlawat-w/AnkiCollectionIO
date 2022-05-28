using AnkiCollectionIO.Schemas.Anki2;

Console.OutputEncoding = System.Text.Encoding.UTF8;

Anki2DbContext dbContext = new Anki2DbContext("./data/collection.anki2");
List<NoteType> noteTypes = dbContext.NoteTypes.ToList();
foreach (NoteType noteType in noteTypes)
{
    Console.WriteLine($"=== NoteType {noteType.Id} | {noteType.Name} ===");
    List<Note> notes = dbContext.Notes
        .Where(note => note.NoteTypeId == noteType.Id)
        .Take(10).ToList();
    foreach (Note note in notes)
    {
        IDictionary<string, string> fieldsDict = note.GetFieldsDictionary(dbContext, value => value.Replace("&nbsp;", "_"));
        foreach (KeyValuePair<string, string> fieldValue in fieldsDict)
        {
            Console.WriteLine($"  {fieldValue.Key} = {fieldValue.Value}");
        }
    }
}
