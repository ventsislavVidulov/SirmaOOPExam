using SirmaOOPExam.Core.Interfaces;
using SirmaOOPExam.Infrastructure.UI.Menus.Interfaces;
using SirmaOOPExam.Infrastructure.UserInterface;

namespace SirmaOOPExam.Infrastructure.UI.Menus.ManageOrders.Options
{
    internal class DisplayAllOrders : IMenuOption
    {
        public string MenuText { get; } = "Display All Orders";
        public int CommandNumber { get; } = 3;

        private IRentalOrderService _rentalOrderService;

        public DisplayAllOrders(IRentalOrderService rentalOrderService)
        {
            _rentalOrderService = rentalOrderService;
        }

        public void Execute()
        {
            ConsoleView.ClearConsole();
            ConsoleView.DisplayHeader("All Orders");

            var orders = _rentalOrderService.GetAllRentalOrders();

            if (orders.Count == 0)
            {
                ConsoleView.DisplayMessage("No orders found.", ConsoleColor.Yellow);
            }
            else
            {
                foreach (var order in orders)
                {
                    ConsoleView.DisplayMessage($"Order ID: {order.Id}, CustomerID: {order.CustomerId}, CarID: {order.CarId}, Start Date: {order.StartDate}, End Date: {order.ExpectedReturnDate}", ConsoleColor.White);
                }
            }

            ConsoleView.PromptToContinue();
        }
    }
}
