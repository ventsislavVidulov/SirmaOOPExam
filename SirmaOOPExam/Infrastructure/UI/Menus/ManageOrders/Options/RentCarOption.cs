using SirmaOOPExam.Core.Interfaces;
using SirmaOOPExam.Core.Models;
using SirmaOOPExam.Infrastructure.UI.Menus.Interfaces;
using SirmaOOPExam.Infrastructure.UserInterface;

namespace SirmaOOPExam.Infrastructure.UI.Menus.ManageOrders.Options
{
    internal class RentCarOption : IMenuOption
    {
        public string MenuText { get; } = "Rent a car";
        public int CommandNumber { get; } = 1;

        public IRentalOrderService _rentalOrderService;
        public RentCarOption(IRentalOrderService rentalOrderService)
        {
            _rentalOrderService = rentalOrderService;
        }

        public void Execute()
        {
            List<ICar> cars = _rentalOrderService.GetCars().Where(c => c.Availability == "Available").ToList();
            List<ICustomer> customers = _rentalOrderService.GetCustomers();
            int lattOrderId = _rentalOrderService.GetAllRentalOrders().Count + 1;

            ConsoleView.DisplayHeader("Rent a Car");
            ConsoleView.DisplayCars(cars);
            if (cars.Count == 0)
            {
                return;
            }
            int carId = ConsoleView.GetIntegerInput("Enter the ID of the car you want to rent: ");
            ConsoleView.DisplayCustomers(customers);
            int customerId = ConsoleView.GetIntegerInput("Enter your customer ID: ");
            DateOnly startDate = ConsoleView.GetDateInput("Enter the start date of the rental (YYYY-MM-DD): ");
            DateOnly endDate = ConsoleView.GetDateInput("Enter the end date of the rental (YYYY-MM-DD): ");
            while (startDate > endDate)
            {
                ConsoleView.DisplayError("Start date cannot be after end date.");
                endDate = ConsoleView.GetDateInput("Please enter a valid end date (YYYY-MM-DD), later than the start date: ");
            }
            _rentalOrderService.AddRentalOrder(new RentalOrder(lattOrderId, carId, customerId, startDate, endDate));
            cars.FirstOrDefault(c => c.Id == carId).RentCar();
            ConsoleView.DisplayMessage($"Car with ID {carId} has been successfully rented to customer with ID {customerId} from {startDate} to {endDate}.", ConsoleColor.Green);
        }
    }
}
