using SirmaOOPExam.Core.Models;

namespace SirmaOOPExam.Infrastructure.FileManagment.Interfaces
{
    internal interface IFileManagerAsync
    {
        Task<List<Car>> GetCarsFromFile();

        Task<List<Customer>> GetCustomersFromFile();

        Task<List<RentalOrder>> GetRentalOrdersFromFile();

        Task SaveCarsToFile(List<Car> cars);

        Task SaveCustomersToFile(List<Customer> customers);

        Task SaveRentalOrdersToFile(List<RentalOrder> rentalOrders);
    }
}