using SirmaOOPExam.Core.Interfaces;

namespace SirmaOOPExam.Core.Models
{
    internal class Car : ICar
    {
        private int _id;
        private string _make;
        private string _model;
        private int _year;
        private string _type;
        private string _availability;
        private string ?_customer;

        public Car(int id, string make, string model, int year, string type, string availability)
        {
            _id = id;
            _make = make;
            _model = model;
            _year = year;
            _type = type;
            _availability = availability;
        }

        public void UpdateCar(int id, string make, string model, int year, string type, string availability, string customer)
        {
            _make = make;
            _model = model;
            _year = year;
            _type = type;
            _availability = availability;
            _customer = customer;
        }
    }
}
