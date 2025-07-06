using SirmaOOPExam.Core.Interfaces;
using SirmaOOPExam.Infrastructure.UI.Menus.Interfaces;
using SirmaOOPExam.Infrastructure.UserInterface;

namespace SirmaOOPExam.Infrastructure.UI.Menus.ManageCars.Options
{
    internal class ViewAllCarsOption : IMenuOption
    {
        public int CommandNumber { get; set; } = 2;
        public string MenuText { get; set; } = "View all cars";

        private ICarsService _carService;

        public ViewAllCarsOption(ICarsService carService)
        {
            _carService = carService;
        }
        public void Execute()
        {
            ConsoleView.DisplayHeader("All Cars");
            List<ICar> cars = _carService.GetCars();
            if (cars.Count == 0)
            {
                ConsoleView.DisplayMessage("No cars available.");
                ConsoleView.PromptToContinue();
                return;
            }
            ConsoleView.DisplayCars(cars);
            ConsoleView.PromptToContinue();
        }
    }
}
