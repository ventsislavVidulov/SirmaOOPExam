namespace SirmaOOPExam.Infrastructure.FileManagment.Interfaces
{
    internal interface ICSVFileManipulator
    {
        Task<List<string[]>> ReadCsvAsync(string filePath);
        Task WriteCsvAsync(string filePath, List<string[]> data);
    }
}