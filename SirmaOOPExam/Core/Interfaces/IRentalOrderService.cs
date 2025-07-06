namespace SirmaOOPExam.Core.Interfaces
{
    internal interface IRentalOrderService
    {
        void AddRentalOrder(IRentalOrder rentalOrder);
        void ReturnCar(int carId);
        List<IRentalOrder> GetAllRentalOrders();
        List<ICar> GetCars();
        List<ICustomer> GetCustomers();
        IRentalOrder? GetRentalOrderById(int id);
    }
}