using SirmaOOPExam.Infrastructure.UI.Menus.Interfaces;

namespace SirmaOOPExam.Infrastructure.UI.Menus.MainMenu.Options
{
    internal class ManageCarsOption : IMenuOption
    {
        public string MenuText { get; } = "Manage Cars (add, list, update)";
        public int CommandNumber { get; } = 2;

        public void Execute()
        {
            // Implementation for managing cars will go here
        }
    }
}
