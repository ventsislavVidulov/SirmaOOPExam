using SirmaOOPExam.Infrastructure.UI.Menus.Interfaces;
using SirmaOOPExam.Infrastructure.UserInterface;

namespace SirmaOOPExam.Infrastructure.UI.Menus.MainMenu
{
    internal class MainMenu : IMenu
    {
        public string Title { get; set; } = "Main Menu";

        public List<IMenuOption> Options = new();

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
            int choice = ConsoleView.GetIntegerInput($"Your choice(1-{Options.Count}): ");
            return choice;
        }
    }
}
