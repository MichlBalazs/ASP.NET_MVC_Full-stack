using GG1RKK_HFT_202324.Models;
using System.Collections.Generic;
using System.Linq;

namespace GG1RKK_HFT_2023241.Logic.Interfaces
{
    public interface IOrderLogic
    {
        void Create(Order item);
        void Delete(int id);
        Order Read(int id);
        IQueryable<Order> ReadAll();
        void Update(Order item);
        int OrderCount(int AdventurerId);
        int OrderedItemsCategory(int OrderId);
        double OrderedItemsAvgPrice();
        string WhoBoughtThisItem(int itemId);
    }
}