using SirmaOOPExam.Core.Interfaces;
using SirmaOOPExam.Core.Models;
using SirmaOOPExam.Infrastructure.UI.Menus.Interfaces;
using SirmaOOPExam.Infrastructure.UserInterface;

namespace SirmaOOPExam.Infrastructure.UI.Menus.ManageCars.Options
{
    internal class AddCarOption : IMenuOption
    {
        public int CommandNumber { get; set; } = 1;
        public string MenuText { get; set; } = "Add a new car";

        private ICarsService _carService;

        public AddCarOption(ICarsService carService)
        {
            _carService = carService;
        }

        public void Execute()
        {
            List<ICar> cars = _carService.GetCars();
            int nextId = cars.Count > 0 ? cars.Max(c => c.Id) + 1 : 1;
            ConsoleView.DisplayHeader("Add a new car");

            string make = ConsoleView.GetStringInput("Enter car make: ");
            string model = ConsoleView.GetStringInput("Enter car model: ");
            int year = ConsoleView.GetIntegerInput("Enter car year: ");
            string type = ConsoleView.GetStringInput("Enter car type: ");


            ICar newCar = new Car(nextId, make, model, year, type, "Available");
            _carService.AddCar(newCar);

            ConsoleView.DisplayMessage($"Car {make} {model} added successfully.");
        }
    }
}
