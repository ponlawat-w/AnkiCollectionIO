using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AnkiCollectionIO.Schemas.Anki21;

namespace AnkiCollectionIO.CLI.TestConsole
{
  public class Program
  {
      public static void Main(string[] args)
      {
          Console.OutputEncoding = Encoding.UTF8;
          using (CollectionReader collectionReader = new CollectionReader("./data/collection.colpkg"))
          {
            List<AnkiCollection> collections = collectionReader.GetCollections();
            foreach (AnkiCollection collection in collections)
            {
                IEnumerable<Model> models = collection.ToModels();
                foreach (Model model in models)
                {
                    Console.WriteLine($"Model {model.Id} | {model.Name}");
                    List<Note> notes = collectionReader.DbContext.Notes.Where(n => n.ModelID == model.Id).Take(10).ToList();
                    foreach (Note note in notes)
                    {
                        IDictionary<string, string> fieldValues = note.GetFieldValue(model);
                        foreach (KeyValuePair<string, string> fieldValue in fieldValues)
                        {
                            Console.Write($"\t{fieldValue.Key} = {fieldValue.Value}");
                        }
                        Console.WriteLine();
                    }
                }
            }
          }
      }
  }
}
