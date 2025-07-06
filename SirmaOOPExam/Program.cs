using SirmaOOPExam.Core.Interfaces;
using SirmaOOPExam.Core.Models;
using SirmaOOPExam.Core.Services;
using SirmaOOPExam.Infrastructure.FileManagment;
using SirmaOOPExam.Infrastructure.FileManagment.Utils;
using System;

namespace SirmaOOPExam
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Car car = new Car(1, "Toyota", "Corolla", 2020, "Sedan", "Available");
            Customer customer = new Customer(1, "John Doe");
            List<IRentalOrder> rentalOrders = new();
            CSVFileManipulator csvFileManipulator = new CSVFileManipulator();
            Converter converter = new Converter();
            FileManagerAsync fileManager = new(csvFileManipulator, converter);
            List<Car> cars = await fileManager.GetCarsFromFile();
            Console.WriteLine(cars.GetType());
            cars.ForEach(c => Console.WriteLine($"{c.Id} - {c.Make} {c.Model} ({c.Year}) - {c.Type}"));
        }
    }
}
