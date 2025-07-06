using SirmaOOPExam.Infrastructure.FileManagment.Interfaces;

namespace SirmaOOPExam.Infrastructure.FileManagment.Utils
{
    internal class Converter : IConverter
    {
        // Converts object property values to a string array, witch is then send to the CSVFileManipulator
        public string[] ConvertToStringArray(object objectToBeConverted)
        {
            var properties = objectToBeConverted.GetType().GetProperties();
            var values = new List<string>();

            foreach (var property in properties)
            {
                var value = property.GetValue(objectToBeConverted);
                values.Add(value?.ToString() ?? "null");
            }

            return values.ToArray();
        }

        // Converts a string array from the "CSV database" to an object of type T
        public T? ConvertToObject<T>(string[] valuesFromCSV) where T : class
        {
            var properties = typeof(T).GetProperties();
            object[] constructorParams = new object[properties.Length];
            Console.WriteLine(properties.Length);
            Console.WriteLine(valuesFromCSV.Length);
            try
            {
                if (properties.Length != valuesFromCSV.Length)
                {
                    throw new ArgumentException("The number of values does not match the number of properties in the object.");
                }

                for (int i = 0; i < properties.Length; i++)
                {
                    var property = properties[i];
                    var convertedValue = Convert.ChangeType(valuesFromCSV[i], property.PropertyType);
                    constructorParams[i] = convertedValue;
                    Console.WriteLine(convertedValue.GetType());
                }

                return (T)Activator.CreateInstance(typeof(T), constructorParams)!;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
    }
}
