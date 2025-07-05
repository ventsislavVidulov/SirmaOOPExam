using SirmaOOPExam.Core.Models;

namespace SirmaOOPExam.Core.Interfaces
{
    internal interface IRentalOrder
    {
        int Id { get; }
        Car Car { get; }

        Customer Customer { get; }

        DateOnly StartDate { get; }

        int PeriodInDays { get; }

        DateOnly ExpectedReturnDate { get; }
    }
}
