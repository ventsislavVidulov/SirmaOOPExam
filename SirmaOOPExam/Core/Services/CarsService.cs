using SirmaOOPExam.Core.Interfaces;

namespace SirmaOOPExam.Core.Services
{
    internal class CarsService : ICarsService
    {
        private List<ICar> _cars;

        public CarsService(List<ICar> cars)
        {
            _cars = cars;
        }

        public List<ICar> GetCars()
        {
            return _cars;
        }

        public ICar? GetCarById(int id)
        {
            return _cars.FirstOrDefault(c => c.Id == id);
        }

        public void AddCar(ICar car)
        {
            _cars.Add(car);
        }

        public void RemoveCarById(int id)
        {
            var car = GetCarById(id);
            if (car != null)
            {
                _cars.Remove(car);
            }
        }

        public void UpdateCar(int id, string make, string model, int year, string type)
        {
            var car = GetCarById(id);
            if (car != null)
            {
                car.UpdateCar(make, model, year, type);
            }
        }
    }
}
