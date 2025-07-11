﻿using SirmaOOPExam.Core.Interfaces;
using SirmaOOPExam.Infrastructure.UserInterface;

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
                car.RetireCar();
            }
            else
            {
                ConsoleView.DisplayError($"Car with ID {id} not found.");
            }
        }

        public void UpdateCarById(int id, string make, string model, int year, string type, string availability)
        {
            var car = GetCarById(id);
            if (car != null)
            {
                car.UpdateCar(make, model, year, type, availability);
            }
            else
            {
                ConsoleView.DisplayError($"Car with ID {id} not found.");
            }
        }
    }
}
