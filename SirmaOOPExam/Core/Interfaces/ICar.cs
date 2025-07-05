using SirmaOOPExam.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SirmaOOPExam.Core.Interfaces
{
    internal interface ICar
    { 
        public void UpdateCar(int id, string make, string model, int year, string type, string availability, string customer);
    }
}
