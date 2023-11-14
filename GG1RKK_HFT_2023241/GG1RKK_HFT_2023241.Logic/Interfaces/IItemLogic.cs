using GG1RKK_HFT_202324.Models;
using System.Linq;

namespace GG1RKK_HFT_2023241.Logic.Interfaces
{
    public interface IItemLogic
    {
        void Create(Item item);
        void Delete(int id);
        Item Read(int id);
        IQueryable<Item> ReadAll();
        void Update(Item item);
    }
}