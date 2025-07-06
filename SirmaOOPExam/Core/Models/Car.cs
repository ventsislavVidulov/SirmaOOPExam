using SirmaOOPExam.Core.Interfaces;

namespace SirmaOOPExam.Core.Models
{
    public class Car : ICar
    {
        public int Id { get; private set; }
        public string Make { get; private set; }
        public string Model { get; private set; }
        public int Year { get; private set; }
        public string Type { get; private set; }
        public string Availability { get; private set; }

        public Car(int id, string make, string model, int year, string type, string availability)
        {
            Id = id;
            Make = make;
            Model = model;
            Year = year;
            Type = type;
            Availability = availability;
        }

        public void RentCar()
        {
            Availability = "Rented";
        }

        public void ReturnCar()
        {
            if (Availability != "Retired")
            {
                Availability = "Available";
            }
        }

        public void PutUnderMaintenance()
        {
            Availability = "Under Maintenance";
        }

        public void RetireCar()
        {
            Availability = "Retired";
        }

        public void UpdateCar(string make, string model, int year, string type)
        {
                Make = make;
                Model = model;
                Year = year;
                Type = type;
        }
    }
}
