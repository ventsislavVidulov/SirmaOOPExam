using SirmaOOPExam.Core.Models;

namespace SirmaOOPExam.Core.Interfaces
{
    internal interface IRentOrder
    {
        int Id { get; }
        Car Car { get; }

        Customer Customer { get; }

        DateTime RentalStartDate { get; }

        int RentalDays { get; }

        DateTime ExpectedReturnDate { get; }
    }
}
