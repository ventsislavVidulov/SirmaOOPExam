using SirmaOOPExam.Infrastructure.UI.Menus.Interfaces;

namespace SirmaOOPExam.Infrastructure.UI.Menus.MainMenu.Options
{
    internal class ManageOrdersOption : IMenuOption
    {
        public string MenuText { get; } = "Manage Orders (rent a car, return a car)";
        public int CommandNumber { get; } = 1;
        public void Execute()
        {
            
        }
    }
}
