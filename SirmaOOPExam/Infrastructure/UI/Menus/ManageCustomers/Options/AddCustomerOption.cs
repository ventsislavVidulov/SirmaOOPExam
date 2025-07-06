using SirmaOOPExam.Core.Interfaces;
using SirmaOOPExam.Core.Models;
using SirmaOOPExam.Core.Services;
using SirmaOOPExam.Infrastructure.UI.Menus.Interfaces;
using SirmaOOPExam.Infrastructure.UserInterface;

namespace SirmaOOPExam.Infrastructure.UI.Menus.ManageCustomers.Options
{
    internal class AddCustomerOption : IMenuOption
    {
        public string MenuText { get; } = "Add Customer";
        public int CommandNumber { get; } = 1;

        private ICustomerService _customerService;
        public AddCustomerOption(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        public void Execute()
        {
            List<ICustomer> customers = _customerService.GetCustomers();
            int nextId = customers.Count > 0 ? customers.Max(c => c.Id) + 1 : 1;
            ConsoleView.DisplayHeader("Add a new customer");

            string name = ConsoleView.GetStringInput("Enter customer name: ");

            ICustomer newCustomer = new Customer(nextId, name);
            _customerService.AddCustomer(newCustomer);

            ConsoleView.DisplayMessage($"Customer {name} added successfully.");
        }
    }
}
