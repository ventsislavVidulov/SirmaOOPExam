using SirmaOOPExam.Core.Interfaces;

namespace SirmaOOPExam.Infrastructure.FileManagment.Interfaces
{
    internal interface IFileManagerAsync
    {
        Task<List<ICar>> GetCarsFromFile();
    }
}