using SirmaOOPExam.Core.Models;
using SirmaOOPExam.Infrastructure.FileManagment.Interfaces;

namespace SirmaOOPExam.Infrastructure.FileManagment
{
    //this class orchestrates the conversion of class members to string arrays and vice versa
    //and writes and reads the data from the CSV files asynchronously
    //the methods generic parameter resive concreate classes because the Converter uses
    //reflection to convert the objects
    internal class FileManagerAsync : IFileManagerAsync
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

        //gets all cars from the file
        public async Task<List<Car>> GetAllCarsFromFile()
        {
            List<Car> cars = new List<Car>();
            //reads the CSV file and convert each line to a Car object
            List<string[]> rawData = await _cSVFileManipulator.ReadCsvAsync(_filePathCar);
            if (rawData == null || rawData.Count == 0)
            {
                return cars;
            }
            else
            {
                foreach (var item in rawData)
                {
                    //convert each string array to a Car object using the converter
                    cars.Add(_converter.ConvertToObject<Car>(item));
                }
                return cars;
            }
        }

        //saves all cars to the file
        public async Task SaveAllCarsToFile(List<Car> cars)
        {
            List<string[]> rawData = new List<string[]>();
            //converts each Car object to a string array and add it to the rawData list
            foreach (var car in cars)
            {
                rawData.Add(_converter.ConvertToStringArray(car));
            }
            // writes the rawData list to the CSV file
            await _cSVFileManipulator.WriteCsvAsync(_filePathCar, rawData);
        }

        //gets all customers from the file, the logic is similar to GetAllCarsFromFile
        public async Task<List<Customer>> GetAllCustomersFromFile()
        {
            List<Customer> customers = new List<Customer>();
            var rawData = await _cSVFileManipulator.ReadCsvAsync(_filePathCustomer);
            if (rawData == null || rawData.Count == 0)
            {
                return customers;
            }
            else
            {
                foreach (var item in rawData)
                {
                    customers.Add(_converter.ConvertToObject<Customer>(item));
                }
                return customers;
            }
        }

        //saves all customers to the file, the logic is similar to SaveAllCarsToFile
        public async Task SaveAllCustomersToFile(List<Customer> customers)
        {
            List<string[]> rawData = new List<string[]>();
            foreach (var customer in customers)
            {
                rawData.Add(_converter.ConvertToStringArray(customer));
            }
            await _cSVFileManipulator.WriteCsvAsync(_filePathCustomer, rawData);
        }

        //gets all rental orders from the file, the logic is similar to GetAllCarsFromFile
        public async Task<List<RentalOrder>> GetAllRentalOrdersFromFile()
        {
            List<RentalOrder> rentalOrders = new List<RentalOrder>();
            var rawData = await _cSVFileManipulator.ReadCsvAsync(_filePathRentalOrder);
            if (rawData == null || rawData.Count == 0)
            {
                return rentalOrders;
            }
            else
            {
                foreach (var item in rawData)
                {
                    rentalOrders.Add(_converter.ConvertToObject<RentalOrder>(item));
                }
                return rentalOrders;
            }
        }

        //saves all rental orders to the file, the logic is similar to SaveAllCarsToFile
        public async Task SaveAllRentalOrdersToFile(List<RentalOrder> rentalOrders)
        {
            List<string[]> rawData = new List<string[]>();
            foreach (var order in rentalOrders)
            {
                rawData.Add(_converter.ConvertToStringArray(order));
            }
            await _cSVFileManipulator.WriteCsvAsync(_filePathRentalOrder, rawData);
        }
    }
}
