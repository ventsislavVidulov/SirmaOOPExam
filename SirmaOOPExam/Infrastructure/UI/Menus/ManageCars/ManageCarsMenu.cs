using SirmaOOPExam.Infrastructure.UI.Menus.Interfaces;
using SirmaOOPExam.Infrastructure.UserInterface;

namespace SirmaOOPExam.Infrastructure.UI.Menus.ManageCars
{
    internal class ManageCarsMenu : IMenu
    {
        public string Title { get; set; } = "Manage Cars";

        public List<IMenuOption> Options { get; set; } = new();

        public void RegisterOption(IMenuOption option)
        {
            Options.Add(option);
        }

        public int DisplayMenu()
        {
            ConsoleView.DisplayHeader(Title);
            foreach (var menuItem in Options)
            {
                ConsoleView.DisplayOption(menuItem);
            }
            int choice = ConsoleView.GetIntegerInput($"Your choice: ");
            return choice;
        }

        public void ExecuteOption(int optionNumber)
        {
            var option = Options.FirstOrDefault(o => o.CommandNumber == optionNumber);
            if (option != null)
            {
                option.Execute();
            }
            else
            {
                ConsoleView.DisplayError("Invalid option selected.");
            }
        }
    }
}
