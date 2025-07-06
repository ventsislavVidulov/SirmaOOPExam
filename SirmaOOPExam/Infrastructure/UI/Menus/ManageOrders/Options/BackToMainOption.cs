using SirmaOOPExam.Infrastructure.UI.Menus.Interfaces;

namespace SirmaOOPExam.Infrastructure.UI.Menus.ManageOrders.Options
{
    internal class BackToMainOption : IMenuOption
    {
        public string MenuText { get; } = "Back to Main Menu";
        public int CommandNumber { get; } = 3;

        public void Execute()
        {
            // Logic to return to the main menu will go here
        }
    }
}
