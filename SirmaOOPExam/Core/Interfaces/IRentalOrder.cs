using SirmaOOPExam.Core.Models;

namespace SirmaOOPExam.Core.Interfaces
{
    internal interface IRentalOrder
    {
        int Id { get; }
        int CarID { get; }

        int CustomerID { get; }

        DateOnly StartDate { get; }

        int PeriodInDays { get; }

        DateOnly ExpectedReturnDate { get; }
    }
}
