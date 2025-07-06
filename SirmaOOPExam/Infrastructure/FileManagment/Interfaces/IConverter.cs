namespace SirmaOOPExam.Infrastructure.FileManagment.Interfaces
{
    internal interface IConverter
    {
        T? ConvertToObject<T>(string[] valuesFromCSV) where T : class;
        string[] ConvertToStringArray(object objectToBeConverted);
    }
}