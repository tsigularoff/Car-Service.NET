namespace CarService.Data.SeedData
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.IO;

    using CarService.Models;

    public class CarModelsReader
    {
        public static ICollection<Manufacturer> GetCarDataFromFile(string filePath)
        {
            var manufacturers = new Dictionary<string, Manufacturer>();

            using (StreamReader reader = new StreamReader(filePath))
            {
                var line = reader.ReadLine();
                var separators = new char[] { ',', '(', ')' };

                while (line != null)
                {
                    var modelInfo = line.Split(separators, StringSplitOptions.RemoveEmptyEntries);

                    var modelYear = int.Parse(modelInfo[0]);
                    var manufacturerName = modelInfo[1].Trim();
                    var modelName = modelInfo[2].Trim();

                    if (!manufacturers.ContainsKey(manufacturerName))
                    {
                        manufacturers.Add(manufacturerName, new Manufacturer
                        {
                            Name = manufacturerName,
                        });
                    }

                    manufacturers[manufacturerName].CarModels.Add(
                            new CarModel
                            {
                                Name = modelName,
                                Year = modelYear
                            });

                    line = reader.ReadLine();
                }
            }

            return manufacturers.Values;
        }

       
    }
}
