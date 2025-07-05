using SirmaOOPExam.Core.Interfaces;

namespace SirmaOOPExam.Core.Models
{
    internal class RentalOrder : IRentalOrder
    {
        public int Id { get; }

        public Car Car { get; private set; }
        // Car is muttable so a "reserved" order can change the car
        public Customer Customer { get; }

        public DateOnly StartDate { get; }

        public int PeriodInDays { get; private set; }
        // Period can be longened if the customer wants to keep the car longer

        public DateOnly ExpectedReturnDate { get; }

        public RentalOrder(int id, Car car, Customer customer, DateOnly startDate, int periodInDays)
        {
            Id = id;
            Car = car;
            Customer = customer;
            StartDate = startDate;
            PeriodInDays = periodInDays;
            ExpectedReturnDate = startDate.AddDays(periodInDays);
        }
    }
}
