using SirmaOOPExam.Infrastructure.UI.Menus.Interfaces;

namespace SirmaOOPExam.Infrastructure.UI.Menus.MainMenu.Options
{
    internal class ExitOption : IMenuOption
    {
        public string MenuText { get; } = "Exit";
        public int CommandNumber { get; } = 4;

        public void Execute()
        {
            Console.WriteLine("Exiting the application. Goodbye!");
            Environment.Exit(0);
        }
    }
}
