using SirmaOOPExam.Core.Interfaces;
using SirmaOOPExam.Infrastructure.UI.Menus.Interfaces;
using SirmaOOPExam.Infrastructure.UserInterface;

namespace SirmaOOPExam.Infrastructure.UI.Menus.ManageCars.Options
{
    internal class RetireCarOption : IMenuOption
    {
        public int CommandNumber { get; set; } = 4;
        public string MenuText { get; set; } = "Retire a car";

        // Assuming there's a service to handle car operations
        private readonly ICarsService _carService;

        public RetireCarOption(ICarsService carService)
        {
            _carService = carService;
        }

        public void Execute()
        {
            ConsoleView.DisplayHeader("Retire Car");
            List<ICar> cars = _carService.GetCars();
            if (cars.Count == 0)
            {
                ConsoleView.DisplayMessage("No cars available to retire.");
                ConsoleView.PromptToContinue();
                return;
            }
            ConsoleView.DisplayCars(cars);
            int carId = ConsoleView.GetIntegerInput("Enter the ID of the car to retire: ");
            _carService.RemoveCarById(carId);
            ConsoleView.DisplayMessage($"Car with ID {carId} has been retired successfully.");
            cars = _carService.GetCars();
            ConsoleView.DisplayCars(cars);
            ConsoleView.PromptToContinue();
        }
    }
}
