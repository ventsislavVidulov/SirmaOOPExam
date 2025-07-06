using SirmaOOPExam.Core.Interfaces;

namespace SirmaOOPExam.Core.Services
{
    internal class CustomerService : ICustomerService
    {
        List<ICustomer> _customers;
        public CustomerService(List<ICustomer> customers)
        {
            _customers = customers;
        }

        public List<ICustomer> GetCustomers()
        {
            return _customers;
        }

        public void AddCustomer(ICustomer customer)
        {
            _customers.Add(customer);
        }
    }
}
