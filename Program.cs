using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Linq;
using System.IO;


namespace Lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            var randomLandPlots = GenerateRandomLandPlots(10);

            SerializeToJson(randomLandPlots, "landplots.json");

            var deserializedLandPlots = DeserializeFromJson("landplots.json");

            foreach (var landPlot in deserializedLandPlots)
            {
                Console.WriteLine(landPlot);
            }
        }

        static List<LandPlot> GenerateRandomLandPlots(int count)
        {
            var random = new Random();
            var landPlots = new List<LandPlot>();
            var names = new[] { "John", "Jane", "Michael", "Sarah", "Robert", "Linda" };

            for (int i = 0; i < count; i++)
            {
                var owner = new Owner(
                    names[random.Next(names.Length)],
                    names[random.Next(names.Length)],
                    DateTime.Now.AddYears(-random.Next(18, 65))
                );
                var description = new Description(
                    random.Next(0, 100),
                    "some soil type",
                    new List<(double, double)>
                    {
                        (random.NextDouble() * 90, random.NextDouble() * 180),
                        (random.NextDouble() * 90, random.NextDouble() * 180)
                    }
                );

                var landPlot = new LandPlot(
                    owner,
                    description,
                    (Purpose)random.Next(3),
                    random.NextDouble() * 100000
                );

                landPlots.Add(landPlot);
            }

            return landPlots;
        }

        static void SerializeToJson(List<LandPlot> landPlots, string fileName)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            var jsonString = JsonSerializer.Serialize(landPlots, options);
            File.WriteAllText(fileName, jsonString);
        }

        static List<LandPlot> DeserializeFromJson(string fileName)
        {
            var jsonString = File.ReadAllText(fileName);
            return JsonSerializer.Deserialize<List<LandPlot>>(jsonString);
        }
    }
}
