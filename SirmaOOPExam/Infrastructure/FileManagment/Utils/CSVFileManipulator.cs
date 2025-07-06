using SirmaOOPExam.Infrastructure.FileManagment.Interfaces;

namespace SirmaOOPExam.Infrastructure.FileManagment.Utils
{
    internal class CSVFileManipulator : ICSVFileManipulator
    {
        //async file read method that reads CSV file line by line and returns a list of string arrays,
        //where each array represents a row in the CSV file
        public async Task<List<string[]>> ReadCsvAsync(string filePath)
        {
            //list to store all rows read from the CSV
            List<string[]> csvData = new List<string[]>();

            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string? readedLine;

                    while ((readedLine = await reader.ReadLineAsync()) != null)
                    {
                        string[] fields = readedLine.Split(',');
                        csvData.Add(fields);
                    }
                }
                Console.WriteLine($"Successfully read data from: {filePath}");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"Error: The file '{filePath}' was not found.");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error reading file '{filePath}': {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred while reading CSV: {ex.Message}");
            }

            return csvData;
        }

        //async file write method that takes a list of string arrays and writes them to a CSV file
        public async Task WriteCsvAsync(string filePath, List<string[]> data)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath, false))
                {
                    foreach (string[] row in data)
                    {
                        await writer.WriteLineAsync(string.Join(",", row));
                    }
                }
                Console.WriteLine($"Successfully wrote data to: {filePath}");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error writing to file '{filePath}': {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred while writing CSV: {ex.Message}");
            }
        }
    }
}
