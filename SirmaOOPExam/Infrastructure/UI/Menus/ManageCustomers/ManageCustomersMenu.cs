using SirmaOOPExam.Infrastructure.UI.Menus.Interfaces;
using SirmaOOPExam.Infrastructure.UserInterface;

namespace SirmaOOPExam.Infrastructure.UI.Menus.ManageCustomers
{
    internal class ManageCustomersMenu : IMenu
    {
        public string Title { get; set; } = "Manage Customers";
        public List<IMenuOption> Options { get; } = new List<IMenuOption>();

        public void RegisterOption(IMenuOption option)
        {
            Options.Add(option);
        }
        public int DisplayMenu()
        {
            ConsoleView.DisplayHeader(Title);
            foreach (var option in Options)
            {
                ConsoleView.DisplayOption(option);
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
