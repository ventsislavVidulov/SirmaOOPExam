using SirmaOOPExam.Core.Models;

namespace SirmaOOPExam.Core.Interfaces
{
    internal interface IRentalOrder
    {
        int Id { get; }
        int CarId { get; }

        int CustomerId { get; }

        DateOnly StartDate { get; }

        DateOnly ExpectedReturnDate { get; }
    }
}
