namespace SirmaOOPExam.Core.Interfaces
{
    internal interface ICustomerService
    {
        void AddCustomer(ICustomer customer);
        List<ICustomer> GetCustomers();
    }
}