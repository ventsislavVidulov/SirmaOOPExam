﻿namespace SirmaOOPExam.Core.Interfaces
{
    public interface ICarsService
    {
        void AddCar(ICar car);
        ICar? GetCarById(int id);
        List<ICar> GetCars();
        void RemoveCarById(int id);
        void UpdateCarById(int id, string make, string model, int year, string type, string availability);
    }
}