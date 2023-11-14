using GG1RKK_HFT_202324.Models;
using System.Linq;

namespace GG1RKK_HFT_2023241.Logic.Interfaces
{
    internal interface IManufacturerLogic
    {
        void Create(Manufacturer item);
        void Delete(int id);
        Manufacturer Read(int id);
        IQueryable<Manufacturer> ReadAll();
        void Update(Manufacturer item);
    }
}