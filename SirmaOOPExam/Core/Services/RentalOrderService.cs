using SirmaOOPExam.Core.Interfaces;

namespace SirmaOOPExam.Core.Services
{
    internal class RentalOrderService : IRentalOrderService
    {
        private List<IRentalOrder> _rentalOrders;
        private List<ICar> _cars;
        private List<ICustomer> _customers;

        public RentalOrderService(List<IRentalOrder> rentalOrders, List<ICar> cars, List<ICustomer> customers)
        {
            _rentalOrders = rentalOrders;
            _cars = cars;
            _customers = customers;
        }

        public List<ICar> GetCars()
        {
            return _cars;
        }

        public List<ICustomer> GetCustomers()
        {
            return _customers;
        }
        public void AddRentalOrder(IRentalOrder rentalOrder)
        {
            _rentalOrders.Add(rentalOrder);
        }

        public List<IRentalOrder> GetAllRentalOrders()
        {
            return _rentalOrders;
        }

        public IRentalOrder? GetRentalOrderById(int id)
        {
            return _rentalOrders.FirstOrDefault(ro => ro.Id == id);
        }
    }
}
