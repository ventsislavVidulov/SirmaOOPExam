using SirmaOOPExam.Core.Models;

namespace SirmaOOPExam.Infrastructure.FileManagment.Interfaces
{
    internal interface IFileManagerAsync
    {
        Task<List<Car>> GetAllCarsFromFile();

        Task<List<Customer>> GetAllCustomersFromFile();

        Task<List<RentalOrder>> GetAllRentalOrdersFromFile();

        Task SaveAllCarsToFile(List<Car> cars);

        Task SaveAllCustomersToFile(List<Customer> customers);

        Task SaveAllRentalOrdersToFile(List<RentalOrder> rentalOrders);
    }
}