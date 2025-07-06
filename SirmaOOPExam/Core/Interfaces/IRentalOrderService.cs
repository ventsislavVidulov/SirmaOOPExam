namespace SirmaOOPExam.Core.Interfaces
{
    internal interface IRentalOrderService
    {
        void AddRentalOrder(IRentalOrder rentalOrder);
        List<IRentalOrder> GetAllRentalOrders();
        List<ICar> GetCars();
        List<ICustomer> GetCustomers();
        IRentalOrder? GetRentalOrderById(int id);
    }
}