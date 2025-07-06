using SirmaOOPExam.Infrastructure.UI.Menus.Interfaces;

namespace SirmaOOPExam.Infrastructure.UI.Menus.ManageOrders.Options
{
    internal class ReturnCarOption : IMenuOption
    {
        public string MenuText { get; } = "Return a car";
        public int CommandNumber { get; } = 2;

        public void Execute()
        {
            // Implementation for returning a car will go here
        }
    }
}
