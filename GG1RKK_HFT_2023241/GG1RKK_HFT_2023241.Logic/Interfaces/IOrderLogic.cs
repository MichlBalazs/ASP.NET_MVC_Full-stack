using GG1RKK_HFT_202324.Models;
using System.Linq;

namespace GG1RKK_HFT_2023241.Logic.Interfaces
{
    internal interface IOrderLogic
    {
        void Create(Order item);
        void Delete(int id);
        Order Read(int id);
        IQueryable<Order> ReadAll();
        void Update(Order item);
    }
}