using SirmaOOPExam.Core.Interfaces;
using SirmaOOPExam.Core.Models;
using SirmaOOPExam.Infrastructure.UI.Menus.Interfaces;
using SirmaOOPExam.Infrastructure.UserInterface;

namespace SirmaOOPExam.Infrastructure.UI.Menus.ManageCars.Options
{
    public class UpdateCarOption : IMenuOption
    {
        public int CommandNumber { get; set; } = 3;
        public string MenuText { get; set; } = "Update an existing car";

        private ICarsService _carService;

        public UpdateCarOption(ICarsService carService)
        {
            _carService = carService;
        }

        public void Execute()
        {
            ConsoleView.DisplayHeader("Update Car");
            List<ICar> cars = _carService.GetCars();
            if (cars.Count == 0)
            {
                ConsoleView.DisplayMessage("No cars available to update.");
                ConsoleView.PromptToContinue();
                return;
            }
            ConsoleView.DisplayCars(cars);
            int carId = ConsoleView.GetIntegerInput("Enter the ID of the car to update: ");
            ICar carToUpdate = _carService.GetCarById(carId);

            if (carToUpdate == null)
            {
                ConsoleView.DisplayError($"No car found with ID {carId}.");
                return;
            }

            string make = ConsoleView.GetStringInput($"Enter new make (current: {carToUpdate.Make}): ");
            string model = ConsoleView.GetStringInput($"Enter new model (current: {carToUpdate.Model}): ");
            int year = ConsoleView.GetIntegerInput($"Enter new year (current: {carToUpdate.Year}): ");
            string type = ConsoleView.GetStringInput($"Enter new type (current: {carToUpdate.Type}): ");
            string availability = ConsoleView.GetStringInput($"Enter new availabiliy (current: {carToUpdate.Availability}): ");
            _carService.UpdateCarById(carToUpdate.Id, make, model, year, type, "Available");

            ConsoleView.DisplayMessage($"Car with ID {carId} updated successfully.");
            ConsoleView.PromptToContinue();
        }
    }

}
