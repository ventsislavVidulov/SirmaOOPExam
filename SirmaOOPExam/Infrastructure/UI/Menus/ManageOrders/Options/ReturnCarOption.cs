using SirmaOOPExam.Core.Interfaces;
using SirmaOOPExam.Infrastructure.UI.Menus.Interfaces;
using SirmaOOPExam.Infrastructure.UserInterface;

namespace SirmaOOPExam.Infrastructure.UI.Menus.ManageOrders.Options
{
    internal class ReturnCarOption : IMenuOption
    {
        public string MenuText { get; } = "Return a car";
        public int CommandNumber { get; } = 2;

        private readonly IRentalOrderService _rentalOrderService;
        public ReturnCarOption(IRentalOrderService rentalOrderService) 
        {
            _rentalOrderService = rentalOrderService;
        }
        public void Execute()
        {
            ConsoleView.DisplayHeader("Return a Car");
            List<ICar> cars = _rentalOrderService.GetCars().Where(c => c.Availability == "Rented").ToList();
            if (cars.Count == 0)
            {
                ConsoleView.DisplayMessage("No cars are currently rented.", ConsoleColor.Yellow);
                ConsoleView.PromptToContinue();
                return;
            }
            ConsoleView.DisplayCars(cars);
            int carId = ConsoleView.GetIntegerInput("Enter the ID of the car you want to return: ");
            ICar car = cars.FirstOrDefault(c => c.Id == carId);
            while (car == null)
            {
                ConsoleView.DisplayError("Car not found. Please enter a valid car ID.");
                return;
            }
            _rentalOrderService.ReturnCar(carId);
            ConsoleView.DisplayMessage($"Car with ID {carId} has been successfully returned.", ConsoleColor.Green);
            ConsoleView.PromptToContinue();
        }
    }
}
