namespace SirmaOOPExam.Core.Interfaces
{
    public interface ICar
    {
        int Id { get; }
        string Make { get; }
        string Model { get; }
        int Year { get; }
        string Type { get; }
        string Availability { get; }

        void RentCar();

        void ReturnCar();

        void PutUnderMaintenance();

        void RetireCar();

        void UpdateCar(string make, string model, int year, string type);

    }
}
