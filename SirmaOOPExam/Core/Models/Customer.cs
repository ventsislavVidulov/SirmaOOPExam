using SirmaOOPExam.Core.Interfaces;

namespace SirmaOOPExam.Core.Models
{
    internal class Customer : ICustomer
    {
        public int Id { get; }
        public string Name { get; }

        public Customer(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
