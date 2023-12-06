using GG1RKK_HFT_202324.Models;
using System.Linq;

namespace GG1RKK_HFT_2023241.Logic.Interfaces
{
    public interface ICategoryLogic
    {
        void Create(Category item);
        void Delete(int id);
        Category Read(int id);
        IQueryable<Category> ReadAll();

        void Update(Category item);
        int GetItemsNumberInCategory(string category);
    }
}