using SirmaOOPExam.Core.Interfaces;

namespace SirmaOOPExam.Core.Services
{
    internal class RentalOrderService
    {
        private List<IRentalOrder> _rentalOrders;

        public RentalOrderService(List<IRentalOrder> rentalOrders)
        {
            _rentalOrders = rentalOrders;
        }

        public void AddRentalOrder(IRentalOrder rentalOrder)
        {
            _rentalOrders.Add(rentalOrder);
        }

        public IEnumerable<IRentalOrder> GetAllRentalOrders()
        {
            return _rentalOrders.AsReadOnly();
        }

        public IRentalOrder? GetRentalOrderById(int id)
        {
            return _rentalOrders.FirstOrDefault(ro => ro.Id == id);
        }
    }
}
