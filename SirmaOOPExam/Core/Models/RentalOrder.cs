using SirmaOOPExam.Core.Interfaces;

namespace SirmaOOPExam.Core.Models
{
        //this class represents a rental order that conects the car to the customer and also makes available reservation of
        //the car (a customer may want to reserve a car in the future time)
    internal class RentalOrder : IRentalOrder
    {
        public int Id { get; }

        public int CarId { get; private set; }

        public int CustomerId  { get; }

        public DateOnly StartDate { get; }

        public DateOnly ExpectedReturnDate { get; private set}

        public RentalOrder(
            int id, 
            int carId, 
            int customerId, 
            DateOnly startDate, 
            DateOnly expectedReturnDate)
        {
            Id = id;
            CarId = carId;
            CustomerId = customerId;
            StartDate = startDate;
            ExpectedReturnDate = expectedReturnDate;
        }
    }
}
