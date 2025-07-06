using SirmaOOPExam.Core.Interfaces;
using SirmaOOPExam.Core.Models;
using SirmaOOPExam.Infrastructure.FileManagment.Interfaces;

namespace SirmaOOPExam.Infrastructure.FileManagment
{
    internal class FileManagerAsync 
        //: IFileManagerAsync
    {
        private string _filePathCar = "../../../Infrastructure/FileManagment/Data/cars.csv";
        private string _filePathCustomer = "../../../Infrastructure/FileManagment/Data/customers.csv";
        private string _filePathRentalOrder = "../../../Infrastructure/FileManagment/Data/rental_orders.csv";

        private ICSVFileManipulator _cSVFileManipulator;
        private IConverter _converter;
        public FileManagerAsync(ICSVFileManipulator cSVFileManipulator, IConverter converter)
        {
            _cSVFileManipulator = cSVFileManipulator;
            _converter = converter;
        }

        public async Task<List<Car>> GetCarsFromFile()
        {
            List<Car> cars = new List<Car>();
            var rawData = await _cSVFileManipulator.ReadCsvAsync(_filePathCar);
            foreach (var item in rawData)
            {
                cars.Add(_converter.ConvertToObject<Car>(item));
            }
            return cars;
        }
    }
}
