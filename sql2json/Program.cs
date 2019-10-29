using System;
using System.IO;
using ACE.Adapter.Lifestoned;

namespace sql2json
{
    public class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine($"Usage: sql2json <filename or folder>");
                return;
            }

            var filename = args[0];
            
            Convert(filename);
        }


        public static void Convert(string filename)
        {
            if (Directory.Exists(filename))
            {
                var di = new DirectoryInfo(filename);

                var files = di.GetFiles("*.sql");
                var folders = di.GetDirectories();

                foreach (var file in files)
                    Convert(file.FullName);

                foreach (var folder in folders)
                    Convert(folder.FullName);

                return;
            }

            if (!File.Exists(filename))
            {
                Console.WriteLine($"File not found: {filename}");
                return;
            }

            var lines = File.ReadAllLines(filename);

            var sqlReader = new SQLReader();
            var weenie = sqlReader.sql2weenie(lines);

            if (!LifestonedConverter.TryConvertACEWeenieToLSDJSON(weenie, out var json))
            {
                Console.WriteLine($"Failed to convert {filename} to json");
                return;
            }

            var jsonFilename = filename.Replace(".sql", ".json");
            File.WriteAllText(jsonFilename, json);

            Console.WriteLine($"Converted {filename} to {jsonFilename}");
        }
    }
}
