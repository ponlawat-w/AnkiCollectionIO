using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.IO;
using System.Linq;
using AnkiCollectionIO;
using AnkiCollectionIO.Schemas;
using CsvHelper;

namespace AnkiCollectionToCsv.CLI.AnkiCollectionToCsv
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                throw new Exception("Invalid arguments. ([0]: path to colpkg, [1]: path to output directory)");
            }
            string pathToCollection = args[0];
            string pathToOutput = args[1];

            Directory.CreateDirectory(pathToOutput);
            using (CollectionReader reader = new CollectionReader(pathToCollection, Path.Combine(pathToOutput, "temp")))
            {
                AnkiCollection collection = reader.GetCollection();
                if (collection == null)
                {
                    throw new Exception("No collections.");
                }

                IEnumerable<Model> models = collection.ToModels();
                foreach (Model model in models)
                {
                    IEnumerable<dynamic> records = new List<dynamic>();
                    List<dynamic> notes = reader.QueryNotes()
                        .Where(n => n.ModelID == model.Id)
                        .OrderBy(n => n.SortField)
                        .Select(n => DictionaryToDynamic(n.GetFieldValue(model, true)))
                        .ToList();
                    
                    if (notes.Count() == 0)
                    {
                        continue;
                    }

                    Console.Write($"Writing note type {model.Name}...");

                    using (StreamWriter writer = new StreamWriter(Path.Combine(pathToOutput, $"{model.Name}.csv")))
                    using (CsvWriter csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture))
                    {
                        csvWriter.WriteRecords(notes);
                    }

                    Console.WriteLine("OK");
                }
            }

            Console.WriteLine("Finish");
        }

        static private dynamic DictionaryToDynamic(IDictionary<string, string> dictionary)
        {
            IDictionary<string, object> expandoObject = (IDictionary<string, object>)new ExpandoObject();
            foreach (KeyValuePair<string, string> dictElement in dictionary)
            {
                expandoObject.Add(new KeyValuePair<string, object>(dictElement.Key, dictElement.Value));
            }

            return expandoObject;
        }
    }
}
